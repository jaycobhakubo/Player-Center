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
    class GetPlayerListDetail : ServerMessage
    {
        PlayerActualListSetting m_pals = new PlayerActualListSetting();
        private int m_DefID;

        public PlayerActualListSetting pals
        {
            get { return m_pals; }
            set { m_pals = value; }
        }


        public GetPlayerListDetail(int DefID)
        {
            m_id = 8038;
            m_DefID = DefID;

            try
            {
                Send();
            }
            catch (ServerCommException ex)
            {
                throw new Exception("GetPlayerListDetail: " + ex.Message);
            }
        }


        protected override void PackRequest()
        {
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);

            requestWriter.Write(m_DefID); //0 or not 0          

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
                ushort ListDefinitionCount = responseReader.ReadUInt16();// 2bytes

                if (ReturnCode == (int)GTIServerReturnCode.Success)
                {
                    for (int i = 0; i < ListDefinitionCount; i++)
                    {
                        m_pals.DefID = responseReader.ReadInt32();
                        m_pals.Definition = ReadString(responseReader);

                        ushort ListDetailCount = responseReader.ReadUInt16();
                        PlayerListSetting pls = new PlayerListSetting();
                        for (int ii = 0; ii < ListDetailCount; ii++)
                        {
                            pls.SettingID = responseReader.ReadInt32();
                            pls.SettingValue = ReadString(responseReader);
                            m_pals.Settings.Add(pls);
                        }
                    }
                }
            }
            catch (EndOfStreamException e)
            {
                throw new MessageWrongSizeException("GetPlayerListDetail:", e);
            }
            catch (Exception e)
            {
                throw new ServerException("GetPlayerListDetail:", e);
            }

            responseReader.Close();
        }
    }
}
