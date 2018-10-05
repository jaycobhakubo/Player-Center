#region Copyright
// This is an unpublished work protected under the copyright laws of the United
// States and other countries.  All rights reserved.  Should publication occur
// the following will apply:  © 2008-2017 GameTech International, Inc.
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTI.Modules.Shared;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace GTI.Modules.PlayerCenter.Data
{
    /// <summary>
    /// Represents a message that returns the sent in configured photo from the server
    /// </summary>
    public class GetPhotoMessage : ServerMessage
    {
        #region Private Members
        private const int MinResponseMessageLength = 8;
        private int m_PhotoID;
        private Bitmap m_Image;
        #endregion

        #region Public Properties

        public int PhotoID
        {
            get { return m_PhotoID; }
            set
            {
                m_PhotoID = value;
            }
        }
        public Bitmap SavedImage
        {
            get { return m_Image; }
            private set
            {
                m_Image = value;
            }
        }
        
        #endregion

        public GetPhotoMessage(int id)
        {
            m_id = 18238;
            m_strMessageName = "Get Configured Photo";

            m_PhotoID = id;
        }

        #region Member Methods

        /// <summary>
        /// Either returns the image that matches the sent in ID
        /// </summary>
        /// <param name="gamingDate"></param>
        /// <returns></returns>
        public static Bitmap GetPhoto(int id)
        {
            var msg = new GetPhotoMessage(id);
            try
            {
                msg.Send();
            }
            catch (ServerCommException ex)
            {
                throw new Exception(msg.MessageName + " Message: " + ex.Message);
            }

            return msg.SavedImage;
        }

        /// <summary>
        /// Prepares the request to be sent to the server.
        /// </summary>
        protected override void PackRequest()
        {
            // Create the streams we will be writing to.
            using (var requestStream = new MemoryStream())
            using (var requestWriter = new BinaryWriter(requestStream, Encoding.Unicode))
            {
                requestWriter.Write(m_PhotoID);

                // Set the bytes to be sent.
                m_requestPayload = requestStream.ToArray();

                // Close the streams.
                requestWriter.Close();
            }
        }

        /// <summary>
        /// Parses the response received from the server.
        /// </summary>
        protected override void UnpackResponse()
        {
            base.UnpackResponse();

            // Create the streams we will be reading from.
            using (var responseStream = new MemoryStream(m_responsePayload))
            using (var reader = new BinaryReader(responseStream, Encoding.Unicode))
            {
                // Try to unpack the data.
                try
                {
                    // Seek past return code.
                    reader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);

                    // Data Length
                    int dataLength = reader.ReadInt32();

                    // Image Data
                    if (dataLength > 0)
                    {
                        // Attempt to load it into a bitmap object.
                        MemoryStream picStream = new MemoryStream(reader.ReadBytes(dataLength));

                        // Rally US493
                        // Create a temporary copy of the image because we can't
                        // keep the picStream open for the lifetime of the image.
                        Bitmap tempBitmap = new Bitmap(picStream);
                        m_Image = new Bitmap(tempBitmap);

                        tempBitmap.Dispose();
                        tempBitmap = null;
                        picStream.Close();
                        picStream.Dispose();
                        picStream = null;
                    }
                    else
                        m_Image = null;
                }
                catch (EndOfStreamException e)
                {
                    throw new MessageWrongSizeException(m_strMessageName, e);
                }
                catch (Exception e)
                {
                    throw new ServerException(m_strMessageName, e);
                }
            }
        }
        #endregion
    }
}
