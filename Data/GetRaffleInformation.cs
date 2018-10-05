using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GTI.Modules.Shared;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace GTI.Modules.PlayerCenter.Data
{
    public class RaffleInfo
    {
         public static int m_playersReq = 0;
         public static int m_currentPlayerCount = 0;
    }


    public class GetRaffleInformation : ServerMessage
    {

        private int m_PlayerListDefId;

        public GetRaffleInformation(int PlayerListDefId)
        {
            m_PlayerListDefId = PlayerListDefId;
            m_id = 18168;
            
        }

        public  void GetNumberOfPlayersRaffleEntry(int PlayerListDefId)
        {
            //m_PlayerListDefId = PlayerListDefId;
            GetRaffleInformation msg = new GetRaffleInformation(PlayerListDefId);
            try
            {
                msg.Send();
            }
            catch (ServerCommException ex)
            {
                throw new Exception("GetNumberOfPlayersRaffleEntry: " + ex.Message);
            }
        }

        protected override void PackRequest()
        {
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);

            requestWriter.Write(m_PlayerListDefId);

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
              

                if (ReturnCode == 0)
                {                 
                    RaffleInfo.m_playersReq = responseReader.ReadInt32();
                    RaffleInfo.m_currentPlayerCount = responseReader.ReadInt32();
                    
                }
            }
            catch (EndOfStreamException e)
            {
                throw new MessageWrongSizeException("Get Number Of Players Raffle Entry", e);
            }
            catch (Exception e)
            {
                throw new ServerException("Get Number Of Players Raffle Entry", e);
            }

            responseReader.Close();
        }
    }
}
