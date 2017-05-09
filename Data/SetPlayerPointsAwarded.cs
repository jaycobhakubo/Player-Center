using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GTI.Modules.Shared;

namespace GTI.Modules.PlayerCenter.Data
{
    class SetPlayerPointsAwarded : ServerMessage
    {
       private int m_playerID { get; set; }
        private string m_playerPointsAwarded { get; set; }
        public SetPlayerPointsAwarded(int playerID, string playerPointsAwarded)
        {
            m_id = 8041;
            m_playerID = playerID;
            m_playerPointsAwarded = playerPointsAwarded;
        }

        public static void Set(int playerID, string playerPointsAwarded)
        {
            SetPlayerPointsAwarded msg = new SetPlayerPointsAwarded(playerID, playerPointsAwarded);
            try
            {
                msg.Send();
            }
            catch (ServerCommException ex)
            {
                throw new Exception("SetPlayerRaffleDefinitions: " + ex.Message);
            }
        }


        protected override void PackRequest()
        {
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);

            requestWriter.Write(m_playerID); //PlayerId

            requestWriter.Write((ushort)m_playerPointsAwarded.Length);//Player points awarded manually
            requestWriter.Write(m_playerPointsAwarded.ToCharArray());

            m_requestPayload = requestStream.ToArray();
            requestWriter.Close();
        }

        protected override void UnpackResponse()
        {
            base.UnpackResponse();

            MemoryStream responseStream = new MemoryStream(m_responsePayload);
            BinaryReader responseReader = new BinaryReader(responseStream, Encoding.Unicode);

            try
            {
                responseReader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);
            }
            catch (EndOfStreamException e)
            {
                throw new MessageWrongSizeException("SetPlayerPointsAwarded:", e);
            }
            catch (Exception e)
            {
                throw new ServerException("SetPlayerPointsAwarded:", e);
            }

            responseReader.Close();
        }
    }
}
