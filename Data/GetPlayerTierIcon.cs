using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTI.Modules.Shared;
using System.IO;
using GTI.Modules.Shared.Business;

namespace GTI.Modules.PlayerCenter.Data
{
    class GetPlayerTierIcon : ServerMessage
    {
        private int m_photoTypeId;
        private List<TierIcon> m_tierIcon;
        protected byte[] mbyteResponsePayload = null;
        protected byte[] mbytResponse = null;
        private int mintReturnCode;
        private List<byte[]> ImageData = null;


        public GetPlayerTierIcon(int photoTypeId_)
        {
            m_id = 18159;
            m_photoTypeId = photoTypeId_;
            m_tierIcon = new List<TierIcon>();
        }

        public static List<TierIcon> Msg(int photoTypeId_)
        {
            GetPlayerTierIcon msg = new GetPlayerTierIcon(photoTypeId_);
            try
            {
                msg.Send();
            }
            catch(ServerCommException ex)
            {
                throw new Exception("GetPlayerTierIcon: " + ex.Message);
            }
            return msg.m_tierIcon;
        }

        protected override void PackRequest()
        {
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);
            requestWriter.Write(m_photoTypeId);
            m_requestPayload = requestStream.ToArray();
            requestWriter.Close();
        }


        public int pReturnCode
        {
            get { return mintReturnCode; }
            //set { mintReturnCode = value; }
        }

        public List<byte[]> pImageData
        {
            get { return ImageData; }
        }

        protected override void UnpackResponse()
        {
            //int intPhotoFieldLength;

            try
            {
                mbytResponse = m_responsePayload;

                if (m_requestPayload == null)
                    throw new ServerCommException("GetPlayerTierIcon.UnpackResponse()..Server communication lost.");

                if (mbytResponse.Length < sizeof(int))
                    throw new MessageWrongSizeException("GetPlayerTierIcon.UnpackResponse()..Message payload size is too small.");

                // Check the return code.
                mintReturnCode = BitConverter.ToInt32(mbytResponse, 0);

                if (mintReturnCode != (int)GTIServerReturnCode.Success)
                {
                    if (mintReturnCode != -18)
                    {
                        throw new ServerException("GetPlayerTierIcon.UnpackResponse()..Server Error Code: " + mintReturnCode.ToString());
                    }
                    else
                    {
                        return;
                    }
                }

                // Create the streams we will be reading from.
                MemoryStream responseStream = new MemoryStream(mbytResponse);
                BinaryReader responseReader = new BinaryReader(responseStream, Encoding.Unicode);

                try
                {

               
                    responseReader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);
                    ushort _count = responseReader.ReadUInt16();
                    ImageData = new List<byte[]>();
                    for (ushort x = 0; x < _count; x++)
                    {
                        var data = new TierIcon();
                        data.TierIconId = responseReader.ReadInt32();

                        //Get Photo Field Length
                       int intPhotoFieldLength = responseReader.ReadInt32();
                        if (intPhotoFieldLength > 0)
                        {
                            data.ImgData = responseReader.ReadBytes(intPhotoFieldLength);
                           // ImageData.Add(responseReader.ReadBytes(intPhotoFieldLength));
                        }
                        else
                        {
                            data.ImgData = null;
                        }
                        m_tierIcon.Add(data);
                    }
                }
                catch (EndOfStreamException e)
                {
                    throw new EndOfStreamException("GetConfigPhotoMessage.UnpackResponse()...EndOfStreamException: ", e);
                }
                catch (Exception e)
                {
                    throw new Exception("GetConfigPhotoMessage.UnpackResponse()...Exception: " + e.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("GetConfigPhotoMessage.UnpackResponse()...Exception: " + ex.Message);
            }

        }

    }


}
