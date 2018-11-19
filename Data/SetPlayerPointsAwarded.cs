using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GTI.Modules.Shared;

namespace GTI.Modules.PlayerCenter.Data
{
    /// <summary>
    /// INPUT:
    ///     (playerID) -> The player id.
    ///     (playerPointsAwardedManually) -> The points value awarded to this player.
    /// RETURN: no return
    /// 
    /// NOTE: Player current points will be updated in MCPPlayerManagementForm.cs
    /// </summary>
    /// 

    class SetPlayerPointsAwarded : ServerMessage
    {  
        private int m_playerID;
        private decimal m_playerPointsAwarded;
        private string m_reason;

        public SetPlayerPointsAwarded(int playerID, decimal playerPointsAwarded, string reason)
        {
            m_id = 8041;
            m_playerID = playerID;
            m_playerPointsAwarded = playerPointsAwarded;
            m_reason = reason;
        }
     
        protected override void PackRequest()
        {
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);

            requestWriter.Write(m_playerID); //PlayerId

            string tmp = m_playerPointsAwarded.ToString();
            requestWriter.Write((ushort)tmp.Length);//Player points awarded manually
            requestWriter.Write(tmp.ToCharArray());

            requestWriter.Write((ushort)m_reason.Length);//Reason player points awarded manually
            requestWriter.Write(m_reason.ToCharArray());
            
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
