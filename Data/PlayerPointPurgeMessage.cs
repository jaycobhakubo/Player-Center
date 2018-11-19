#region Copyright
// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2008 GameTech
// International, Inc.
#endregion

using System;
using System.IO;
using System.Text;
using System.Globalization;
using GTI.Modules.Shared;
using GTI.Modules.PlayerCenter.Business;
using GTI.Modules.PlayerCenter.Properties;

namespace GTI.Modules.PlayerCenter.Data
{
    /// <summary>
    /// Represents a Create New Player server message.
    /// </summary>
    internal class PlayerPointPurgeMessage : ServerMessage
    {
        #region Constants and Data Types
        protected const int ResponseMessageLength = 8;
        #endregion

        #region Member Variables
        public enum Operation
        {
            GetLastPurgeInfo = 0,
            Purge = 1,
            UndoPurge = 2
        }

        protected Operation m_operation = Operation.GetLastPurgeInfo;
        protected DateTime m_purgeDate = DateTime.Now;
        protected string m_purgeMethod = string.Empty;

        protected int m_playersChanged = 0;
        protected DateTime m_lastPurgeDate = DateTime.Now;
        protected string m_lastPurgeMethod = string.Empty;
        protected string m_lastPurgeBy = string.Empty;
        protected int m_lastPurgePlayersChanged = 0;
        protected string m_reasonForPurge = string.Empty;
        protected string m_reasonForLastPurge = string.Empty;

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the CreateNewPlayerMessage class.
        /// </summary>
        public PlayerPointPurgeMessage()
        {
            m_id = 8042; 
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

            //operation
            requestWriter.Write((int)m_operation);

            //date
            string tempDate = m_purgeDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

            requestWriter.Write((ushort)tempDate.Length);
            requestWriter.Write(tempDate.ToCharArray());

            //purge method
            requestWriter.Write((ushort)m_purgeMethod.Length);
            requestWriter.Write(m_purgeMethod.ToCharArray());
            
            //purge reason
            requestWriter.Write((ushort)m_reasonForPurge.Length);
            requestWriter.Write(m_reasonForPurge.ToCharArray());

            // Set the bytes to be sent.
            m_requestPayload = requestStream.ToArray();

            // Close the streams.
            requestWriter.Close();
        }

        /// <summary>
        /// Parses the response received from the server.
        /// </summary>
        protected override void UnpackResponse()
        {
            base.UnpackResponse();

            // Create the streams we will be reading from.
            MemoryStream responseStream = new MemoryStream(m_responsePayload);
            BinaryReader responseReader = new BinaryReader(responseStream, Encoding.Unicode);

            // Check the response length.
            if(responseStream.Length < ResponseMessageLength)
                throw new MessageWrongSizeException("Player Points Purge");

            // Try to unpack the data.
           
            // Seek past return code.
            responseReader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);

            m_playersChanged = responseReader.ReadInt32();

            int stringLen = responseReader.ReadUInt16();
            string tempDate = new string(responseReader.ReadChars(stringLen));

            if (tempDate != string.Empty)
                m_lastPurgeDate = DateTime.Parse(tempDate, CultureInfo.InvariantCulture);

            stringLen = responseReader.ReadUInt16();
            m_lastPurgeMethod = new string(responseReader.ReadChars(stringLen));

            stringLen = responseReader.ReadUInt16();
            m_lastPurgeBy = new string(responseReader.ReadChars(stringLen));

            m_lastPurgePlayersChanged = responseReader.ReadInt32();

            stringLen = responseReader.ReadUInt16();
            m_reasonForLastPurge = new string(responseReader.ReadChars(stringLen));
            
            // Close the streams.
            responseReader.Close();
        }
        #endregion

        #region Member Properties


        public Operation PurgeOperation
        {
            get
            {
                return m_operation;
            }
            
            set
            {
                m_operation = value;
            }
        }

        public DateTime PurgeIfLastVisitWasBeforeThisDate
        {
            get
            {
                return m_purgeDate;
            }
            
            set
            {
                m_purgeDate = value;
            }
        }

        public string PurgeMethod
        {
            get
            {
                return m_purgeMethod;
            }
         
            set
            {
                m_purgeMethod = value;
            }
        }

        public int PlayersChanged
        {
            get
            {
                return m_playersChanged;
            }
        }

        public DateTime LastPurgeDate
        {
            get
            {
                return m_lastPurgeDate;
            }
        }

        public string LastPurgeMethod
        {
            get
            {
                return m_lastPurgeMethod;
            }
        }

        public string LastPurgedBy
        {
            get
            {
                return m_lastPurgeBy;
            }
        }

        public int PlayersChangedByLastPurge
        {
            get
            {
                return m_lastPurgePlayersChanged;
            }
        }

        public string ReasonForPurge
        {
            get
            {
                return m_reasonForPurge;
            }

            set
            {
                m_reasonForPurge = value;
            }
        }

        public string ReasonForLastPurge
        {
            get
            {
                if (string.IsNullOrWhiteSpace(m_reasonForLastPurge))
                    return "None";

                return m_reasonForLastPurge;
            }

            set
            {
                m_reasonForLastPurge = value;
            }
        }

        #endregion
    }
}
