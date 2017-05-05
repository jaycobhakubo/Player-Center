#region Copyright
// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2008 GameTech
// International, Inc.
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GTI.Modules.Shared;

namespace GTI.Modules.PlayerCenter.Data
{

    class GetPlayerLocation : ServerMessage
    {

        private const int MinResponseMessageLenght = 6;
        private List<LocationCity> CityList;
        private List<LocationState> StateList;
        private List<LocationZipCode> ZipCodeList;
        private List<LocationCountry> CountryList; 

        public GetPlayerLocation()
        {
            m_id = 8034;
            CityList  = new List<LocationCity>(); 
            StateList  = new List<LocationState>();
            ZipCodeList  = new List<LocationZipCode>();
            CountryList  = new List<LocationCountry>(); 

        }
        

        #region Member Methods

        public static void GetPlayerLocationX()
        {
            GetPlayerLocation msg = new GetPlayerLocation();
            try
            {
                msg.Send();
            }
            catch (ServerCommException ex)
            {
                throw new Exception("GetPlayerLocation: " + ex.Message);
            }
        }

        protected override void PackRequest()
        {
            MemoryStream requestStream = new MemoryStream();
            m_responsePayload = requestStream.ToArray();

        }

        protected override void UnpackResponse()
        {
            base.UnpackResponse();

            MemoryStream responseStream = new MemoryStream(m_responsePayload);
            BinaryReader responseReader = new BinaryReader(responseStream, Encoding.Unicode);

            if (responseStream.Length < MinResponseMessageLenght)
            {
                throw new MessageWrongSizeException("Get Player Location City, State, Code and Country List");
            }



            try
            {
                responseReader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);

                ushort countCity = responseReader.ReadUInt16();    
                CityList.Clear(); 
                for (ushort x = 0; x < countCity; x++)
                {
                    LocationCity code = new LocationCity();
                    ushort stringLen = responseReader.ReadUInt16();
                    code.City = new string(responseReader.ReadChars(stringLen));
                    CityList.Add(code);                   
                }
                GetPlayerLocationPer.CityName = CityList; 

        
                ushort countZipCode = responseReader.ReadUInt16();
                ZipCodeList.Clear();  
                for (ushort x = 0; x < countZipCode; x++)
                {
                    LocationZipCode code = new LocationZipCode();
                    ushort stringlen = responseReader.ReadUInt16();
                    code.ZipCode = new string(responseReader.ReadChars(stringlen));
        
                    ZipCodeList.Add(code);   
                }
                GetPlayerLocationPer.ZipCodeName = ZipCodeList;  


                ushort countState = responseReader.ReadUInt16();           
                StateList.Clear();
                for (ushort x = 0; x < countState; x++)
                {
                    LocationState code = new LocationState();
                    ushort stringLen = responseReader.ReadUInt16();
                    code.State = new string(responseReader.ReadChars(stringLen));
                    StateList.Add(code);              
                }
                GetPlayerLocationPer.StateName = StateList;   


                ushort countCountry = responseReader.ReadUInt16();
                CountryList.Clear(); 
                for (ushort x = 0; x < countCountry; x++)
                {
                    LocationCountry code = new LocationCountry();
                    ushort stringLen = responseReader.ReadUInt16();
                    code.Country = new string(responseReader.ReadChars(stringLen));
           
                    CountryList.Add(code); 
                }
                GetPlayerLocationPer.CountryName = CountryList;


            }
            catch (EndOfStreamException e)
            {
                throw new MessageWrongSizeException("Get Player Location City, State, Code and Country List", e);
            }
            catch (Exception e)
            {
                throw new ServerException("Get Player Location City, State, Code and Country List", e);
            }
            responseReader.Close();
        }


    }
        #endregion
}
