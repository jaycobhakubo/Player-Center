using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Globalization;
using GTI.Modules.Shared;

namespace GTI.Modules.PlayerCenter.Data
{
    public class GetPlayerTierRulesDatam : ServerMessage
    {
        private const int MinResponseMessageLenght = 6;
        private TierRulesData tierRulesData { get; set; }


            public GetPlayerTierRulesDatam()
            {
                m_id = 18207;
                tierRulesData = new TierRulesData();
            }

            public static void GetPlayerTierRules()
            {
                GetPlayerTierRulesDatam msg = new GetPlayerTierRulesDatam();
                try
                {
                    msg.Send();
                }
                catch(ServerException ex)
                {
                    throw new Exception("GetPlayerTierRules: " + ex.Message);
                }

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
                    TierRulesData code = new TierRulesData();
                    code.TierRulesID = responseReader.ReadInt32();//0
                    code.DefaultTierID = responseReader.ReadInt32();//0
                    code.DowngradeToDefault = responseReader.ReadBoolean();//false ?
                    
                    stringLen = responseReader.ReadUInt16();
                    string tempDate = new string(responseReader.ReadChars(stringLen));//"" 1/1/0001 12:00:00AM
                    if (!string.IsNullOrEmpty(tempDate))
                    { code.QualifyingStartDate = DateTime.Parse(tempDate, CultureInfo.InvariantCulture); }//If its NULL it will set to 1/1/0001 12:00:00 AM automatically


                    stringLen = responseReader.ReadUInt16();
                    tempDate = new string(responseReader.ReadChars(stringLen));
                    if (!string.IsNullOrEmpty(tempDate))
                    { code.QualifyingEndDate = DateTime.Parse(tempDate, CultureInfo.InvariantCulture); }

                    GetPlayerTierRulesData.getPlayerTierRulesData = code; //save it here

         
                    
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
