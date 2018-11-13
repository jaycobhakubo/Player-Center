//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GTI.Modules.Shared;

namespace GTI.Modules.PlayerCenter.Data
{
   public class SetPlayerTierData :  ServerMessage
    {
       protected const int ResponseMessageLenght = 8;//4 or 8 or 6       
       private int TierID { get; set; }
       private int TierRulesID { get; set; }
       private string TierName { get; set; }
       private int TierColor { get; set; }
       private decimal AmntSpend { get; set; }
       private decimal NbrPoints { get; set; }
       private decimal PtsMultiplier { get; set; }
       private bool isdelete { get; set; }

       public SetPlayerTierData(TierData td)//td is emtpy we can get the one that has data let us try this for now
       {
           m_id = 18073;
           TierID = td.TierID;
           TierRulesID = td.TierRulesID;
           TierName = td.TierName;
           TierColor = td.TierColor;
           AmntSpend = td.AmntSpend;
           NbrPoints = td.NbrPoints;
           PtsMultiplier = td.Multiplier;
           isdelete = td.isdelete;
       }

       public static int Save(TierData td)
       {
           SetPlayerTierData msg = new SetPlayerTierData(td);
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
           string tempDec = AmntSpend.ToString();//what is this Cultureinfo.Invariant Culture
           //Amount Spend
           requestWriter.Write((ushort)tempDec.Length);
           requestWriter.Write(tempDec.ToCharArray());
           //Points 
           tempDec = NbrPoints.ToString();
           requestWriter.Write((ushort)tempDec.Length);
           requestWriter.Write(tempDec.ToCharArray());
           //Multiplier
           tempDec = PtsMultiplier.ToString();
           requestWriter.Write((ushort)tempDec.Length);
           requestWriter.Write(tempDec.ToCharArray());

           requestWriter.Write(isdelete);//

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


