#region Copyright
// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2008 GameTech
// International, Inc.
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GTI.Modules.Shared;

namespace GTI.Modules.PlayerCenter.Data
{
    class GetOperatorPlayerStatusList : ServerMessage 
    {
   
        
        private int OperatorId { get; set; }
        private const int MinResponseMessageLength = 6;
        private List<PlayerStatus> StatusCodes { get; set; }
 
        public GetOperatorPlayerStatusList(int operatorId)
        {
            m_id = 8024;
            OperatorId = operatorId;
            StatusCodes = new List<PlayerStatus>();
        }

        #region Member Methods
        public static List<PlayerStatus> GetOperatorPlayerStatus(int operatorId)
        {
            GetOperatorPlayerStatusList msg = new GetOperatorPlayerStatusList(operatorId);
            try
            {
                msg.Send();
            }
            catch (ServerCommException ex)
            {
                throw new Exception("GetOperatorPlayerStatus: " + ex.Message);
            }
            return msg.StatusCodes;
        }





        /// <summary>
        /// Prepares the request to be sent to the server.
        /// </summary>
        protected override void PackRequest()
        {
            // Create the streams we will be writing to.
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);

            requestWriter.Write(OperatorId);

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
            if (responseStream.Length < MinResponseMessageLength)
                throw new MessageWrongSizeException("Get Operator Player Status");

            // Try to unpack the data.
            try
            {
                // Seek past return code.
                responseReader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);

                // Get the count of players.
                ushort count = responseReader.ReadUInt16();
                StatusCodes.Clear();

                // Get all the player status
                for (ushort x = 0; x < count; x++)
                {
                    
                    PlayerStatus code = new PlayerStatus();
                    code.Id = responseReader.ReadInt32(); 
                    ushort stringLen = responseReader.ReadUInt16();
                    code.Name = new string(responseReader.ReadChars(stringLen));
                    code.IsActive = responseReader.ReadBoolean();
                    code.IsAlert = responseReader.ReadBoolean();
                    code.Banned = responseReader.ReadBoolean();

                    if (code.Banned == true)
                    {
                        code.Banned_string = "TRUE";
                    }
                    else
                    {
                        code.Banned_string = "FALSE";
                    }

                    StatusCodes.Add(code);
                }
            }
            catch (EndOfStreamException e)
            {
                throw new MessageWrongSizeException("Get Operator Player Status", e);
            }
            catch (Exception e)
            {
                throw new ServerException("Get Operator Player Status", e);
            }

            // Close the streams.
            responseReader.Close();
        }

        #endregion
    }
}
