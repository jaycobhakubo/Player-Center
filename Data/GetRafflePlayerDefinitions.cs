using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GTI.Modules.Shared;

namespace GTI.Modules.PlayerCenter.Data
{
    //class RaffleDefinitionList
    //{
    //    public static List<RaffleDefinition> getData = new List<RaffleDefinition>();
    //}

    //class RaffleDefinition
    //{
    //    public int RaffleDefID;
    //    public string RaffleName;
    //    public int RafflePlayerCount;
    //    public string RaffleDescription;

    //    public int RaffleDefIDgs
    //    {
    //        get { return RaffleDefID; }
    //        set { RaffleDefID = value; }
    //    }

    //    public string RaffleNamegs
    //    {
    //        get { return RaffleName; }
    //        set { RaffleName = value; }
    //    }

    //    public int RafflePlayersCountgs
    //    {
    //        get { return RafflePlayerCount; }
    //        set { RafflePlayerCount = value; }
    //    }

    //    public string RaffleDescriptiongs
    //    {
    //        get { return RaffleDescription; }
    //        set { RaffleDescription = value; }
    //    }
            

    //}

  public  class GetRafflePlayerDefinitions : ServerMessage
    {


        public GetRafflePlayerDefinitions()
        {
            m_id = 18209;
        }

        public void runGetRafflePlayerDefinitions()
        {
            GetRafflePlayerDefinitions msg = new GetRafflePlayerDefinitions();
            try
            {
                msg.Send();
            }
            catch (ServerCommException ex)
            {
                throw new Exception("runGetRafflePlayerDefinitions: " + ex.Message);
            }
        }

        protected override void PackRequest()
        {
        }

        protected override void UnpackResponse()
        {
              base.UnpackResponse();

            MemoryStream responseStream = new MemoryStream(m_responsePayload);
            BinaryReader responseReader = new BinaryReader(responseStream, Encoding.Unicode);         
            try
            {



               responseReader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);//? what is this script do
               ushort RaffleCount = responseReader.ReadUInt16();//Raffle Count

               List_DataRafflePrize.LDataRafflePrize.Clear();

                if (ReturnCode == 0)
                {
                    for (ushort startCount = 0; startCount < RaffleCount; startCount++)
                    {
                        DataRafflePrizes data = new DataRafflePrizes();
                        data.gsRaffleID = responseReader.ReadInt32();//Raffle definition ID
                        data.gsNoOfRafflePrize = responseReader.ReadInt32();//Number of Players to Draw
                        ushort stringLen = responseReader.ReadUInt16();//Raffle Name Len
                        data.gsRaffleName = new string(responseReader.ReadChars(stringLen));//Raffle Name
                        stringLen = responseReader.ReadUInt16();//Raffle Description Len
                        data.gsRafflePrizeDescription = new string(responseReader.ReadChars(stringLen));//Raffle Description
                        //what if its null.
                        stringLen = responseReader.ReadUInt16();//Raffle Disclaimer Len
                        data.gsRaffleDisclaimer = new string(responseReader.ReadChars(stringLen));//Raffle Disclaimer
                        List_DataRafflePrize.LDataRafflePrize.Add(data);
                    }
                }
            }
            catch (EndOfStreamException e)
            {
                throw new MessageWrongSizeException("Get Raffle Player Definition", e);
            }
            catch (Exception e)
            {
                throw new ServerException("Get Raffle Player Definition", e);
            }

            responseReader.Close();
        }    

        


    }
}
