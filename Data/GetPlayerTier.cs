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
        private const int MinResponseMessageLenght = 2;
        private List<Tier> m_tiers;
        private int m_tierID;
        private int m_tierDefaultId;


        public GetPlayerTier(int tierId)
        {
            m_id = 18072;
            m_tierID = tierId;
            m_tiers = new List<Tier>();
        } 

        public static List<Tier> Msg(int _tierID, int _tierDefaultId)//this can return set of list of data
        {
            GetPlayerTier msg = new GetPlayerTier(_tierID);
            msg.m_tierDefaultId = _tierDefaultId;
            try
            {
                msg.Send();
            }
            catch (ServerException ex)
            {
                throw new Exception("GetPlayerTierData: " + ex.Message);
            }

            return msg.m_tiers;
        }

        protected override void PackRequest()
        {
            //throw new NotImplementedException();
            // Create the streams we will be writing to.
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);

            requestWriter.Write(m_tierID);

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
                    { code.QualifyingSpend = decimal.Parse(tempDec); }

                    stringLen = responseReader.ReadUInt16();
                    tempDec = new string(responseReader.ReadChars(stringLen));
                    if (!string.IsNullOrEmpty(tempDec))
                    {
                        code.QualifyingPoints = decimal.Parse(tempDec);
                    }

                    stringLen = responseReader.ReadUInt16();
                    tempDec = new string(responseReader.ReadChars(stringLen));
                    if (!string.IsNullOrEmpty(tempDec))
                    {
                        code.AwardPointsMultiplier = decimal.Parse(tempDec);
                    }

                    code.TierIconId = responseReader.ReadInt32();

                    if (m_tierDefaultId == code.TierID)
                    {
                        code.IsDefaultTier = true; //code.TierName = new string(responseReader.ReadChars(stringLen)) + " (default)";
                    }
                    else
                    {
                        code.IsDefaultTier = false; //code.TierName = new string(responseReader.ReadChars(stringLen));
                    }

                    m_tiers.Add(code);
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
