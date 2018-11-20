using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GTI.Modules.Shared;
using GTI.Modules.Shared.Business;

namespace GTI.Modules.PlayerCenter.Data
{
    public class SetPlayerTierRule : ServerMessage
    {
        protected const int ResponseMessageLenght = 8;

        private int TierRuleID { get; set; }
        private int DefaultTierID {get; set;}
        private bool DownToDefault { get; set; }
        private DateTime QualifyingStartDate {get; set;}
        private DateTime QualifyingEndDate {get; set;}

        public SetPlayerTierRule(TierRule trd)
        {
            m_id = 18208;
            TierRuleID = trd.TierRulesID;
            DefaultTierID = trd.DefaultTierID;
            DownToDefault = trd.DowngradeToDefault;
            QualifyingStartDate = trd.QualifyingStartDate;
            QualifyingEndDate = trd.QualifyingEndDate;

        }

        public static int Save(TierRule trd)
        {
            SetPlayerTierRule msg = new SetPlayerTierRule(trd);
            try
            {
                msg.Send();
            }
            catch(ServerCommException ex)
            {
                throw new Exception("SetPlayerTierRule: " + ex.Message);
            }

            return msg.TierRuleID;
        }

        protected override void  PackRequest()
        {
             MemoryStream requestStream = new MemoryStream();
           BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);
 	            
            requestWriter.Write(TierRuleID);
            requestWriter.Write(DefaultTierID);
            //requestWriter.Write(DownToDefault);
            requestWriter.Write((byte)(DownToDefault ? 1 : 0));
           string tempDate = string.Empty;
            tempDate = QualifyingStartDate.ToString();
            requestWriter.Write((ushort)tempDate.Length);
            requestWriter.Write(tempDate.ToCharArray());

             tempDate = string.Empty;
            tempDate = QualifyingEndDate.ToString();
            requestWriter.Write((ushort)tempDate.Length);
            requestWriter.Write(tempDate.ToCharArray());

             m_requestPayload = requestStream.ToArray();
           requestWriter.Close();
        }

        protected override void  UnpackResponse()
        {
 	        base.UnpackResponse();
            MemoryStream responseStream = new MemoryStream(m_responsePayload);
            BinaryReader responseReader = new BinaryReader(responseStream, Encoding.Unicode);

            if (responseStream.Length != ResponseMessageLenght)//How should I know how many lenght its giving me back
           {
               throw new MessageWrongSizeException("Set Player Tier Rule");
           }


            try
            {
                 responseReader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);
                TierRuleID = responseReader.ReadInt32();
            }
            catch(EndOfStreamException e)
            {
                throw new MessageWrongSizeException("Set Player Tier Rule", e);
            }
            catch(Exception e )
            {
                 throw new ServerException("SetOperatorPlayerStatus", e);
            }

        }

    }
}