using System;
using System.IO;
using System.Text;
using GTI.Modules.Shared;

namespace GTI.Modules.PlayerCenter.Data
{
    public class SetOperatorPlayerStatus : ServerMessage
    {
        protected const int MinResponseMessageLength = 8;
        private int OperatorId { get; set; }
        private int StatusId { get; set; }
        private string StatusName { get; set; }
        private bool IsActive { get; set; }
        private bool IsAlert { get; set; }
        private bool Banned { get; set; }

        public SetOperatorPlayerStatus(int operatorId, PlayerStatus ps)
        {
            m_id = 8025;
            OperatorId = operatorId;
            StatusId = ps.Id;
            StatusName = ps.Name;
            IsAlert = ps.IsAlert;
            IsActive = ps.IsActive;
            Banned = ps.Banned;
        }

        public static int Save(int operatorId, PlayerStatus ps)
        {
            SetOperatorPlayerStatus msg = new SetOperatorPlayerStatus(operatorId, ps);
            try
            {
                msg.Send();
            }
            catch (ServerCommException ex)
            {
                throw new Exception("SetOperatorPlayerStatus: " + ex.Message);
            }
            return msg.StatusId;
        }

        protected override void PackRequest()
        {
            // Create the streams we will be writing to.
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);

            // Status Id
            requestWriter.Write(StatusId);

            // Operator Id
            requestWriter.Write(OperatorId);

            // Status Name
            requestWriter.Write((ushort)StatusName.Length);
            requestWriter.Write(StatusName.ToCharArray());

            // IsActive flag
            requestWriter.Write(IsActive);

            // Alert flag
            requestWriter.Write(IsAlert);

            // Banned flag
            requestWriter.Write(Banned);
            
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
                throw new MessageWrongSizeException("SetOperatorPlayerStatus");

            // Try to unpack the data.
            try
            {
                // Seek past return code.
                responseReader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);

                // get the Player Status code Id
                StatusId = responseReader.ReadInt32();
            }
            catch (EndOfStreamException e)
            {
                throw new MessageWrongSizeException("SetOperatorPlayerStatus", e);
            }
            catch (Exception e)
            {
                throw new ServerException("SetOperatorPlayerStatus", e);
            }

            // Close the streams.
            responseReader.Close();
        }    
    }
}
