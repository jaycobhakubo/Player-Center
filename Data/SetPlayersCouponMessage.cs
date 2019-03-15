using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GTI.Modules.Shared;

namespace GTI.Modules.PlayerCenter.Data
{
    class SetPlayersCouponMessage : ServerMessage
    {
        private int m_playerId;
        private int m_playerCouponId;

        public SetPlayersCouponMessage(int playerId, int playerCouponId)
        {
            m_id = 18265;
            m_playerId = playerId;
            m_playerCouponId = playerCouponId;
        }


        protected override void PackRequest()
        {
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);
            requestWriter.Write(m_playerId); //PlayerId
            requestWriter.Write(m_playerCouponId); //CouponId          
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
