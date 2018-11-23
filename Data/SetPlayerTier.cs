//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GTI.Modules.Shared;
using GTI.Modules.Shared.Business;

namespace GTI.Modules.PlayerCenter.Data
{
   public class SetPlayerTier :  ServerMessage
    {
       protected const int ResponseMessageLenght = 8;//4 or 8 or 6       
       private int TierID { get; set; }
       private int TierRulesID { get; set; }
       private string TierName { get; set; }
       private int TierColor { get; set; }
       private decimal QualifyingSpend { get; set; }
       private decimal QualifyingPoints { get; set; }
       private decimal PtsMultiplier { get; set; }
       private bool IsDelete { get; set; }

       public SetPlayerTier(Tier td)//td is emtpy we can get the one that has data let us try this for now
       {
           m_id = 18073;
           TierID = td.TierID;
           TierRulesID = td.TierRulesID;
           TierName = td.TierName;
           TierColor = td.TierColor;
           QualifyingSpend = td.QualifyingSpend;
           QualifyingPoints = td.QualifyingPoints;
           PtsMultiplier = td.AwardPointsMultiplier;
           IsDelete = td.IsDelete;
       }

       public static int Msg(Tier td)
       {
           SetPlayerTier msg = new SetPlayerTier(td);
           try
           {
               msg.Send();
           }
           catch (ServerCommException ex)
           {
               throw new Exception("SetPlayerTierData: " + ex.Message);
           }
           return msg.TierID;
       }


       protected override void PackRequest()
       {
           MemoryStream requestStream = new MemoryStream();
           BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);

           requestWriter.Write(TierID); //0 or not 0
           requestWriter.Write(TierRulesID);
           requestWriter.Write((ushort)TierName.Length);
           requestWriter.Write(TierName.ToCharArray());
           requestWriter.Write(TierColor);
           string tempDec = QualifyingSpend.ToString();//what is this Cultureinfo.Invariant Culture
           //Amount Spend
           requestWriter.Write((ushort)tempDec.Length);
           requestWriter.Write(tempDec.ToCharArray());
           //Points 
           tempDec = QualifyingPoints.ToString();
           requestWriter.Write((ushort)tempDec.Length);
           requestWriter.Write(tempDec.ToCharArray());
           //AwardPointsMultiplier
           tempDec = PtsMultiplier.ToString();
           requestWriter.Write((ushort)tempDec.Length);
           requestWriter.Write(tempDec.ToCharArray());

           requestWriter.Write(IsDelete);//

           m_requestPayload = requestStream.ToArray();
           requestWriter.Close();
           //throw new NotImplementedException();
       }


       protected override void UnpackResponse()
       {
           base.UnpackResponse();

           MemoryStream responseStream = new MemoryStream(m_responsePayload);
           BinaryReader responseReader = new BinaryReader(responseStream, Encoding.Unicode);

           if (responseStream.Length != ResponseMessageLenght)//How should I know how many lenght its giving me back
           {
               throw new MessageWrongSizeException("Set Player Tier Data");
           }

           try
           {
               responseReader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);
               TierID = responseReader.ReadInt32(); //it give me back TierID now what??

           }
           catch (EndOfStreamException e)
           {
               throw new MessageWrongSizeException("Set Player Tier Data",e);
           }
           catch (Exception e)
           {
               throw new ServerException("SetOperatorPlayerStatus", e);
           }

           responseReader.Close();


       }



    }
}


