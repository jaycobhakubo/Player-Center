#region Copyright
// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2008 GameTech
// International, Inc.
#endregion

using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using GTI.Modules.Shared;

namespace GTI.Modules.PlayerCenter.Data
{
    /// <summary>
    /// Represents a Set Player Image server message.
    /// </summary>
    internal class SetPlayerImageMessage : ServerMessage
    {
        #region Member Variables
        protected int m_playerId = 0;
        protected Bitmap m_image = null;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the SetPlayerImageMessage class.
        /// </summary>
        public SetPlayerImageMessage()
            : this(0, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SetPlayerImageMessage class
        /// with the specified player id and picture.
        /// </summary>
        /// <param name="playerId">The id of the player who's 
        /// picture to set.</param>
        /// <param name="image">The picture of the player or null to 
        /// set no picture on the server.</param>
        public SetPlayerImageMessage(int playerId, Bitmap image)
        {
            m_id = 8021; // Set Player Image
            m_playerId = playerId;
            m_image = image;
        }
        #endregion

        #region Member Methods
        /// <summary>
        /// Prepares the request to be sent to the server.
        /// </summary>
        protected override void PackRequest()
        {
            // Create the streams we will be writing to.
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);
            
            // Player Id
            requestWriter.Write(m_playerId);

            // Get the bytes of the picture.
            MemoryStream picStream = new MemoryStream();

            if(m_image != null)
                m_image.Save(picStream, ImageFormat.Jpeg);

            // Picture Size
            requestWriter.Write((int)picStream.Length);

            // Picture
            if(picStream.Length > 0)
                requestWriter.Write(picStream.ToArray());

            // Set the bytes to be sent.
            m_requestPayload = requestStream.ToArray();

            // Close all the streams.
            picStream.Close();
            requestWriter.Close();
        }
        #endregion

        #region Member Properties
        /// <summary>
        /// Gets or sets the id of the player who's picture to set.
        /// </summary>
        public int PlayerId
        {
            get
            {
                return m_playerId;
            }
            set
            {
                m_playerId = value;
            }
        }

        /// <summary>
        /// The player's picture to save to the server or null to set 
        /// no picture.
        /// </summary>
        public Bitmap Image
        {
            get
            {
                return m_image;
            }
            set
            {
                m_image = value;
            }
        }
        #endregion
    }
}
