using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using GTI.Modules.PlayerCenter.UI;
using System.IO;
using GTI.Modules.Shared;

namespace GTI.Modules.PlayerCenter.Data
{
    class SetPlayerList : ServerMessage
    {
        //playerlis
        private PlayerActualListSetting m_playerDefinitionSetting;
        private int m_DefId;
        private bool m_isSuccess = false;

        public bool IsSuccess
        {
            get { return m_isSuccess; }
            set { m_isSuccess = value; }
        }

        public PlayerActualListSetting playerdefinitionSetting
        {
            get { return m_playerDefinitionSetting; }
            set { m_playerDefinitionSetting = value; }
        }



        public int SetPlayerListMSG(PlayerActualListSetting pals)//Gtiservice message.
        {
            m_id = 8037;
            m_playerDefinitionSetting = pals;

            try
            {
                Send();
            }
            catch (ServerCommException ex)
            {
                throw new Exception("SetPlayerList: " + ex.Message);
            }
            return m_DefId;
        }

        protected override void PackRequest()
        {
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);

            requestWriter.Write(m_playerDefinitionSetting.DefID); //0 or not 0

            WriteString(requestWriter, m_playerDefinitionSetting.Definition);

            requestWriter.Write(m_playerDefinitionSetting.Deleted);

            requestWriter.Write(m_playerDefinitionSetting.Settings == null ? (ushort)0 : (ushort)m_playerDefinitionSetting.Settings.Count);
            if (m_playerDefinitionSetting.Settings != null)
            {
                foreach (PlayerListSetting setting in m_playerDefinitionSetting.Settings)
                {
                    requestWriter.Write(setting.SettingID);
                    WriteString(requestWriter, setting.SettingValue);
                }
            }

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
                if (ReturnCode == (int)GTIServerReturnCode.Success)
                {
                    m_DefId = responseReader.ReadInt32();
                    m_isSuccess = true; // JAN- the base class throws an exception if it's not a "success" so this property isn't very useful..
                }
            }
            catch (EndOfStreamException e)
            {
                throw new MessageWrongSizeException("SetPlayerList:", e);
            }
            catch (Exception e)
            {
                throw new ServerException("SetPlayerList:", e);
            }

            responseReader.Close();
        }
    }
}
