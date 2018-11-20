using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Globalization;
using GTI.Modules.Shared;
using GTI.Modules.Shared.Business;

namespace GTI.Modules.PlayerCenter.Data
{
    public class GetPlayerTier : ServerMessage
    {
        private const int MinResponseMessageLenght = 2;// Why is it 2//Will reasearch
       // private List<TierData> tierData { get; set; }
        private List<Tier> Tiers; //{ get; set; }
        private int TierID { get; set; }

        public GetPlayerTier(int tierId)
        {
            m_id = 18072;
            TierID = tierId;
            Tiers = new List<Tier>();
        } 

        // public static void GetPlayerTierData()
       // public static List<TierData> Msg(int tierID)//this can return set of list of data
              public static List<Tier> Msg(int tierID)//this can return set of list of data
        {
            GetPlayerTier msg = new GetPlayerTier(tierID);
            try
            {
                msg.Send();
            }
            catch (ServerException ex)
            {
                throw new Exception("GetPlayerTierData: " + ex.Message);
            }

            return msg.Tiers;
        }

        protected override void PackRequest()
        {
            //throw new NotImplementedException();
            // Create the streams we will be writing to.
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);

            requestWriter.Write(TierID);

            // Set the bytes to be sent.
            m_requestPayload = requestStream.ToArray();

            // Close the streams.
            requestWriter.Close();
        }

        protected override void UnpackResponse()
        {
            base.UnpackResponse();

            MemoryStream responseStream = new MemoryStream(m_responsePayload);
            BinaryReader responseReader = new BinaryReader(responseStream, Encoding.Unicode);

            if (responseStream.Length < MinResponseMessageLenght)//responseStream = 4 < 6
            {
                throw new MessageWrongSizeException("Get Player Tier Data");
            }

            try
            {
                //let us try one data for now
                responseReader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);
                ushort TierCount = responseReader.ReadUInt16();

                
                for (ushort x = 0; x < TierCount; x++)
                {
                   var code = new Tier();
                    code.TierID = responseReader.ReadInt32();
                    code.TierRulesID = responseReader.ReadInt32();

                    ushort stringLen = responseReader.ReadUInt16(); 
                    code.TierName = new string(responseReader.ReadChars(stringLen));                   
                    
                    code.TierColor = responseReader.ReadInt32();

                    stringLen = responseReader.ReadUInt16();
                    string tempDec = new string(responseReader.ReadChars(stringLen));
                    if (!string.IsNullOrEmpty(tempDec))
                    { code.AmntSpend = decimal.Parse(tempDec); }

                    stringLen = responseReader.ReadUInt16();
                    tempDec = new string(responseReader.ReadChars(stringLen));
                    if (!string.IsNullOrEmpty(tempDec))
                    {
                        code.NbrPoints = decimal.Parse(tempDec);
                    }

                    stringLen = responseReader.ReadUInt16();
                    tempDec = new string(responseReader.ReadChars(stringLen));
                    if (!string.IsNullOrEmpty(tempDec))
                    {
                        code.Multiplier = decimal.Parse(tempDec);
                    }

                    Tiers.Add(code);

                    //if (TierID == 0)
                    //{
                    //    GetPlayerTierData.getPlayerTierData.Add(code);
                        
                    //}
                }

            }
            catch (EndOfStreamException e)
            {
                throw new MessageWrongSizeException("Get Player Data", e);
            }
            catch (Exception e)
            {
                throw new ServerException("Get Player Tier Data", e);
            }

            responseReader.Close();

        }

    }
}
