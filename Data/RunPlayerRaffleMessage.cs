#region Copyright
// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2008 GameTech
// International, Inc.
#endregion

using System;
using System.IO;
using System.Text;
using GTI.Modules.Shared;

namespace GTI.Modules.PlayerCenter.Data
{
    /// <summary>
    /// The possible status return codes from the Run Player Raffle 
    /// server message.
    /// </summary>
    public enum RunPlayerRaffleReturnCode
    {
        NotEnoughPlayers = 1,
        RaffleInProgress = 3
    }

    /// <summary>
    /// Represents a Run Player Raffle server message.
    /// </summary>
    public class RunPlayerRaffleMessage : ServerMessage
    {
        #region Constants and Data Types
        protected const int MinResponseMessageLength = 8;
        #endregion

        #region Member Variables
        protected int m_playerId = 0;
        protected string m_playerFirstName = string.Empty;
        protected string m_playerLastName = string.Empty;
        #endregion

        #region Cosntructors
        /// <summary>
        /// Initializes a new instance of the RunPlayerRaffleMessage class.
        /// </summary>
        public RunPlayerRaffleMessage()
        {
            m_id = 18035; // Run Player Raffle
        }
        #endregion

        #region Member Methods
        /// <summary>
        /// Prepares the request to be sent to the server.
        /// </summary>        
        protected override void PackRequest()
        {
        }

        /// <summary>
        /// Parses the response received from the server.
        /// </summary>
        protected override void UnpackResponse()
        {
            try
            {
                base.UnpackResponse();
            }
            catch(ServerException e)
            {
                // If it's a positive return code, then it's okay.
                if((int)e.ReturnCode > 0)
                    return;
                else
                    throw e; // Rethrow
            }

            // Create the streams we will be reading from.
            MemoryStream responseStream = new MemoryStream(m_responsePayload);
            BinaryReader responseReader = new BinaryReader(responseStream, Encoding.Unicode);

            // Check the response length.
            if (responseStream.Length < MinResponseMessageLength)
                throw new MessageWrongSizeException("Run Player Raffle");

            // Try to unpack the data.
            try
            {
                // Seek past return code.
                responseReader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);

                // Player's Id
                m_playerId = responseReader.ReadInt32();

                // Player's First Name
                short stringLen = responseReader.ReadInt16();
                m_playerFirstName = new string(responseReader.ReadChars(stringLen));

                // Player's Last Name
                stringLen = responseReader.ReadInt16();
                m_playerLastName = new string(responseReader.ReadChars(stringLen));

            }
            catch (EndOfStreamException e)
            {
                m_playerId = 0;
                m_playerFirstName = null;
                m_playerLastName = null;
                throw new MessageWrongSizeException("Run Player Raffle", e);
            }
            catch (Exception e)
            {
                m_playerId = 0;
                m_playerFirstName = null;
                m_playerLastName = null;
                throw new ServerException("Run Player Raffle", e);
            }

            // Close the streams.
            responseReader.Close();
        }
        #endregion

        #region Member Properties
        /// <summary>
        /// Gets the the player id.
        /// </summary>
        public int PlayerId
        {
            get
            {
                return m_playerId;
            }
        }

        /// <summary>
        /// Gets the player's first name.
        /// </summary>
        public string PlayerFirstName
        {
            get
            {
                return m_playerFirstName;
            }
        }

        /// <summary>
        /// Gets player's last name.
        /// </summary>
        public string PlayerLastName
        {
            get
            {
                return m_playerLastName;
            }
        }
        #endregion
    }
}
