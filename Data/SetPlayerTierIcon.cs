using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTI.Modules.Shared;
using System.IO;


namespace GTI.Modules.PlayerCenter.Data
{
    class SetPlayerTierIcon :  ServerMessage
    {
        private int m_photoTypeId = 0;
        private int m_photoLength = 0;
        private byte[] m_imageData = null;

        public SetPlayerTierIcon(byte[] photo_)
        {
            m_id = 18160;
            m_photoTypeId = 13;
            if (photo_ != null)
            {
                m_imageData = photo_;
                m_photoLength = photo_.Length;
            }            
        }

        public static void Msg(byte[] photo_)
        {
            SetPlayerTierIcon msg = new SetPlayerTierIcon(photo_);
            try
            {
                msg.Send();
            }
            catch (ServerCommException ex)
            {
                throw new Exception("SetPlayerTierIcon: " + ex.Message);
            }
        }

        protected override void PackRequest()
        {
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);
            requestWriter.Write(m_photoTypeId);
            requestWriter.Write(m_photoLength);
            if (m_photoLength > 0)
            {
                requestWriter.Write(m_imageData);
            }
            m_requestPayload = requestStream.ToArray();
            requestWriter.Close();
        }
        protected byte[] m_bytResponse = null;
        private int m_intReturnCode;

        protected override void UnpackResponse()
        {
            try
            {
                m_bytResponse = m_responsePayload;

                if (m_requestPayload == null)
                    throw new ServerCommException("SetPlayerTierIcon.UnpackResponse()..Server communication lost.");

                if (m_bytResponse.Length < sizeof(int))
                    throw new MessageWrongSizeException("SetPlayerTierIcon.UnpackResponse()..Message payload size is too small.");

                m_intReturnCode = BitConverter.ToInt32(m_bytResponse, 0);

                if (m_intReturnCode != (int)GTIServerReturnCode.Success)
                    throw new ServerException("SetPlayerTierIcon.UnpackResponse()..Server Error Code: " + m_intReturnCode.ToString());

                MemoryStream responseStream = new MemoryStream(m_bytResponse);
                BinaryReader responseReader = new BinaryReader(responseStream, Encoding.Unicode);
                responseReader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);

                try
                {

                }
                catch (EndOfStreamException e)
                {
                    throw new EndOfStreamException("SetConfigPhotoMessage.UnpackResponse()...EndOfStreamException: ", e);
                }
                catch (Exception e)
                {
                    throw new Exception("SetConfigPhotoMessage.UnpackResponse()...Exception: " + e.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("SetConfigPhotoMessage.UnpackResponse()...Exception: " + ex.Message);
            }

        }
    }
}
