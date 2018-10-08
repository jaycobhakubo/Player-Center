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
    /// Represents a message to update the sent in photo record to the sent in image
    /// </summary>
    public class SetPhotoMessage : ServerMessage
    {
        #region Private Members

        private int m_photoID;
        private Bitmap m_image;

        #endregion

        #region Public Properties

        public int PhotoID
        {
            get { return m_photoID; }
            set
            {
                m_photoID = value;
            }
        }
        public Bitmap SavedImage
        {
            get { return m_image; }
            set
            {
                m_image = value;
            }
        }

        #endregion

        public SetPhotoMessage(int photoID, Bitmap image)
        {
            m_id = 18237;
            m_strMessageName = "Set Photo";

            m_photoID = photoID;
            m_image = image;
        }

        #region Member Methods

        /// <summary>
        /// Updates the sent in image.
        /// </summary>
        /// <param name="raffle"></param>
        /// <param name="delete"></param>
        /// <returns></returns>
        public static void SetPhoto(int photoID, Bitmap image)
        {
            var msg = new SetPhotoMessage(photoID, image);
            try
            {
                msg.Send();
            }
            catch (ServerCommException ex)
            {
                throw new Exception(msg.MessageName + " Message: " + ex.Message);
            }
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
                requestWriter.Write(m_photoID);

                // get the bytes of the picture
                MemoryStream picStream = new MemoryStream();
                if (m_image != null)
                    m_image.Save(picStream, ImageFormat.Png);

                // pic size
                requestWriter.Write((int)picStream.Length);

                // pic itself
                if (picStream.Length > 0)
                    requestWriter.Write(picStream.ToArray());

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
