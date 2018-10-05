//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GTI.Modules.Shared;
using GTI.Modules.PlayerCenter.Data;

namespace GTI.Modules.PlayerCenter
{
    class GetPackageNameList : ServerMessage 
    {
        private int OperatorID { get; set; }
        private const int MinResponseMessageLenght = 6;
        private List<ProductList> ProductName { get; set; }

        public GetPackageNameList(int operatorId) //need the same name as the class
        {
            m_id = 18078;
            OperatorID = operatorId;
            ProductName = new List<ProductList>(); 
        }

        public static List<ProductList> GetProduct(int operatorId)
        {
            GetPackageNameList msg = new GetPackageNameList(operatorId);

            try
            {
                msg.Send();
            }
            catch (ServerCommException ex)
            {
                throw new Exception("GetProduct: " + ex.Message); 
            }

            return msg.ProductName;

        }


        protected override void PackRequest()
        {            
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode );
            requestWriter.Write(0);
            requestWriter.Write(OperatorID);   
            m_requestPayload = requestStream.ToArray();
            requestWriter.Close(); 
        }


        protected override void UnpackResponse()
        {
            base.UnpackResponse();
            MemoryStream responseStream = new MemoryStream(m_responsePayload);
            BinaryReader responseReader = new BinaryReader(responseStream, Encoding.Unicode );

            if (responseStream.Length < MinResponseMessageLenght)
            {
                throw new MessageWrongSizeException("Get Product"); 
            }

            try
            {
                responseReader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);
                ushort count = responseReader.ReadUInt16();
                ProductName.Clear();

                for (ushort x = 0; x < count; x++)
                {
                    ProductList product = new ProductList();
                    product.PackageID = responseReader.ReadInt32();
                  
                    product.ChargeDeviceFee = responseReader.ReadBoolean();

                    ushort stringLen = responseReader.ReadUInt16();
                    product.PackageName = new string(responseReader.ReadChars(stringLen));

                    stringLen = responseReader.ReadUInt16();
                   product.ReceiptText = new string(responseReader.ReadChars(stringLen));     

                   stringLen = responseReader.ReadUInt16();
                   product.Packageprice = new string(responseReader.ReadChars(stringLen));
                   ProductName.Add(product);   
                }
         
       

            }

            catch (EndOfStreamException e)
            {
                throw new MessageWrongSizeException("Get Product", e);
            }
            catch (Exception e)
            {
                throw new ServerException("Get Product", e); 
            }

            responseReader.Close();  

        }



    }
}
