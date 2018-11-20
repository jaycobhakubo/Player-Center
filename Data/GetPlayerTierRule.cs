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
    public class GetPlayerTierRule : ServerMessage
    {
        private const int MinResponseMessageLenght = 6;
        //private TierRulesData tierRulesData { get; set; }

        private TierRule m_tierRule; 

            public GetPlayerTierRule()
            {
                m_id = 18207;
                m_tierRule  = new TierRule();
                //tierRulesData = new TierRulesData();
            }

            public static TierRule Msg()
            {
                GetPlayerTierRule msg = new GetPlayerTierRule();
                try
                {
                    msg.Send();
                }
                catch(ServerException ex)
                {
                    throw new Exception("GetPlayerTierRules: " + ex.Message);
                }
                return msg.m_tierRule;
            }

            protected override void PackRequest()
            {
            }

            protected override void UnpackResponse()
            {
                base.UnpackResponse();

                ushort stringLen;
                MemoryStream responseStream = new MemoryStream(m_responsePayload);
                BinaryReader responseReader = new BinaryReader(responseStream, Encoding.Unicode);

                if (responseStream.Length < MinResponseMessageLenght)
                {
                    throw new MessageWrongSizeException("Get Player Tier Rules");
                }

                try
                {
                   
                    responseReader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);//Maybe this is the return code

                    m_tierRule.TierRulesID = responseReader.ReadInt32();//0
                    m_tierRule.DefaultTierID = responseReader.ReadInt32();//0
                    m_tierRule.DowngradeToDefault = responseReader.ReadBoolean();//false ?
                    
                    stringLen = responseReader.ReadUInt16();
                    string tempDate = new string(responseReader.ReadChars(stringLen));//"" 1/1/0001 12:00:00AM
                    if (!string.IsNullOrEmpty(tempDate))
                    { m_tierRule.QualifyingStartDate = DateTime.Parse(tempDate, CultureInfo.InvariantCulture); }//If its NULL it will set to 1/1/0001 12:00:00 AM automatically


                    stringLen = responseReader.ReadUInt16();
                    tempDate = new string(responseReader.ReadChars(stringLen));
                    if (!string.IsNullOrEmpty(tempDate))
                    { m_tierRule.QualifyingEndDate = DateTime.Parse(tempDate, CultureInfo.InvariantCulture); }

                    //GetPlayerTierRulesData.getPlayerTierRulesData = code; //save it here                    
                }
                catch(EndOfStreamException e)
                {
                    throw new MessageWrongSizeException("Get Player Tier Rules", e);
                }
                catch(Exception e)
                {
                    throw new ServerException("Get Player Tier Rules", e);
                }

                responseReader.Close();

            }


    }
}
