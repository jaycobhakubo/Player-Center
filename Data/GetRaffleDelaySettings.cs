using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GTI.Modules.Shared;

namespace GTI.Modules.PlayerCenter.Data
{
    public class RaffleDelayValue
    {
        public static int Id;
        public static int Category;
        public static string Value;
    }


   public class GetRaffleDelaySettings:ServerMessage
    {
       private int m_operatorId { get; set; }
       private int m_machineId { get; set; }
       private int m_category { get; set; }
       private int m_globalSettingId { get; set; }
       protected string m_displayedText;

       public GetRaffleDelaySettings(int settingID, int operatorID)
       {
           m_id = 18100;
           m_operatorId = operatorID;
           m_machineId = 0;
           m_category = 0;
           m_globalSettingId = settingID;//Raffle Duration from globalsetting
    
       }


       public static void RunGetRaffleDelaySetting(int settingID, int operatorID)
       {
           GetRaffleDelaySettings msg = new GetRaffleDelaySettings(settingID,operatorID );
           try
           {
               msg.Send();
           }
           catch (ServerCommException ex)
           {
               throw new Exception("RunGetRaffleDelaySetting: " + ex.Message);
           }
       }

       protected override void PackRequest()
       {
           MemoryStream requestStream = new MemoryStream();
           BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);

           // Operator Id
           requestWriter.Write(m_operatorId);

           // Machine Id
           requestWriter.Write(m_machineId);

           // Setting Category Id
           requestWriter.Write((int)m_category);

           // Global Setting Id
           requestWriter.Write((int)m_globalSettingId);

           // Set the bytes to be sent.
           m_requestPayload = requestStream.ToArray();

           // Close the streams.
           requestWriter.Close();
       }

       protected override void UnpackResponse()
       {
           base.UnpackResponse();

           // Create the streams we will be reading from.
           MemoryStream responseStream = new MemoryStream(m_responsePayload);
           BinaryReader responseReader = new BinaryReader(responseStream, Encoding.Unicode);

           // Check the response length.
           //if (responseStream.Length < MinResponseMessageLength)
           //    throw new MessageWrongSizeException("Get System Settings");

           // Try to unpack the data.
           try
           {
               // Seek past return code.
               responseReader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);

               // Get the count of settings.
               ushort settingsCount = responseReader.ReadUInt16();

               // Clear the settings array.
              // m_settings = new SettingValue[settingsCount];

               RaffleSetting data = new RaffleSetting();

               // Read all the settings.
               for (ushort x = 0; x < settingsCount; x++)
               {
              

                   // Setting Id

                   data.RaffleSettingID = responseReader.ReadInt32();
                   if (data.RaffleSettingID == 214)
                   {
                       RaffleDelayValue.Id = data.RaffleSettingID;
                   }
                   // Category Id
                   int temp = responseReader.ReadInt32();
                   if (data.RaffleSettingID == 214)
                   {
                       RaffleDelayValue.Category = temp;
                   }
                   // Length of the setting.
                   ushort stringLen = responseReader.ReadUInt16();

                   // The setting value.
                   data.RaffleSettingValue = new string(responseReader.ReadChars(stringLen));
                   if (data.RaffleSettingID == 214)
                   {
                       RaffleDelayValue.Value = data.RaffleSettingValue;
                   }
                   else if (data.RaffleSettingID == 182)
                   {
                       //DisplayedText = data.RaffleSettingValue.ToString();
                   }
                   else if (data.RaffleSettingID == 271)
                   {
                    //   RaffleLocation = Convert.ToInt32(data.RaffleSettingValue);
                   }
                

                   //m_settings[x] = setting;
                   RaffleSettings.data.Add(data);
               }
           }
           catch (EndOfStreamException e)
           {
               throw new MessageWrongSizeException("Get System Settings", e);
           }
           catch (Exception e)
           {
               throw new ServerException("Get System Settings", e);
           }

           // Close the streams.
           responseReader.Close();
       }


       //public static string DisplayedText;
     //  public static int RaffleLocation; //1 is caller 2 is player center

    }
}
