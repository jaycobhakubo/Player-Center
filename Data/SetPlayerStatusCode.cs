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
    public class SetPlayerStatusCode : ServerMessage
    {
        protected const int MinResponseMessageLength = 4;
        private int PlayerId { get; set; }
        private List<PlayerStatus> StatusList { get; set; }
        private List<int> BadStatus { get; set; }

        public SetPlayerStatusCode(int playerId, List<PlayerStatus> statuses)
        {
            m_id = 8027;
            PlayerId = playerId;
            StatusList = statuses;
            BadStatus = new List<int>();
        }

        public static List<int> Save(int playerId, List<PlayerStatus> statuses)
        {
            SetPlayerStatusCode msg = new SetPlayerStatusCode(playerId, statuses);
            try
            {
                msg.Send();
            }
            catch (ServerCommException ex)
            {
                throw new Exception("SetPlayerStatusCode: " + ex.Message);
            }
            return msg.BadStatus;
        }

        protected override void PackRequest()
        {
            // Create the streams we will be writing to.
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);

            // Player Id
            requestWriter.Write(PlayerId);

            // count
            requestWriter.Write((ushort)StatusList.Count);
            foreach (PlayerStatus status in StatusList)
            {
                // send only Id
                requestWriter.Write(status.Id);
            }
            // Set the bytes to be sent.
            m_requestPayload = requestStream.ToArray();

            // Close the streams.
            requestWriter.Close();
        }

        protected override void UnpackResponse()
        {
            base.UnpackResponse();

            // Create the streams we will be reading from.
            MemoryStream responseStream = new MemoryStream(m_responsePayload);
            BinaryReader responseReader = new BinaryReader(responseStream, Encoding.Unicode);

            // Check the response length.
            if (responseStream.Length < MinResponseMessageLength)
                throw new MessageWrongSizeException("SetPlayerStatusCode");

            // Try to unpack the data.
            try
            {
                // Seek past return code.
                responseReader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);

                if (responseStream.Length > MinResponseMessageLength)
                {
                    // Get the BadStatusCode count.
                    BadStatus.Clear();
                    short count = responseReader.ReadInt16();
                    while (count-- > 0)
                    {
                        BadStatus.Add(responseReader.ReadInt32());
                    }
                }
            }
            catch (EndOfStreamException e)
            {
                throw new MessageWrongSizeException("SetPlayerStatusCode", e);
            }
            catch (Exception e)
            {
                throw new ServerException("SetPlayerStatusCode", e);
            }

            // Close the streams.
            responseReader.Close();
        }
    }

}
