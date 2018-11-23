using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GTI.Modules.Shared;

namespace GTI.Modules.PlayerCenter.Data
{
    class SetPlayerRaffleDefinitions : ServerMessage//18210
    {
        private int RaffleDefID { get; set; }
        private bool isDelete { get; set; }
        private int NumberOfPlayersToDraw { get; set; }
        private string RaffleName { get; set; }
        private string RaffleDefinition { get; set; }
        private string RaffleDisclaimer { get; set; }

        public SetPlayerRaffleDefinitions(DataRafflePrizes rd, bool IsDelete)
        {
            m_id = 18210;
            RaffleDefID = rd.RaffleID;
            isDelete = IsDelete;
            NumberOfPlayersToDraw = rd.NoOfRafflePrize;
            RaffleName = rd.RaffleName;
            RaffleDefinition = rd.RafflePrizeDescription;
            RaffleDisclaimer = rd.RaffleDisclaimer;
        }

        public static int Set(DataRafflePrizes rd, bool IsDelete)
        {
            SetPlayerRaffleDefinitions msg = new SetPlayerRaffleDefinitions(rd, IsDelete);
            try
            {
                msg.Send();
            }
            catch (ServerCommException ex)
            {
                throw new Exception("SetPlayerRaffleDefinitions: " + ex.Message);
            }

            return msg.RaffleDefID;
        }


        protected override void PackRequest()
        {
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);

            requestWriter.Write(RaffleDefID); 
            requestWriter.Write(isDelete);

            requestWriter.Write(NumberOfPlayersToDraw);
            requestWriter.Write((ushort)RaffleName.Length);
            requestWriter.Write(RaffleName.ToCharArray());

            requestWriter.Write((ushort)RaffleDefinition.Length);
            requestWriter.Write(RaffleDefinition.ToCharArray());

            requestWriter.Write((ushort) RaffleDisclaimer.Length);
            requestWriter.Write(RaffleDisclaimer.ToCharArray());

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
                RaffleDefID = responseReader.ReadInt32(); //it give me back TierID now what??

            }
            catch (EndOfStreamException e)
            {
                throw new MessageWrongSizeException("SetPlayerRaffleDefinitions:", e);
            }
            catch (Exception e)
            {
                throw new ServerException("SetPlayerRaffleDefinitions:", e);
            }

            responseReader.Close();


        }


    }
}
