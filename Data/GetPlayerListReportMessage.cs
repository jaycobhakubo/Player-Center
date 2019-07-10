#region Copyright
// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2008 GameTech
// International, Inc.
#endregion

// Rally US144

using System;
using System.IO;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using GTI.Modules.Shared;
using GTI.Modules.PlayerCenter.Business;

namespace GTI.Modules.PlayerCenter.Data
{
    /// <summary>
    /// Holds player information to be exported.
    /// </summary>
    public struct PlayerExportItem
    {
        public Player Player;
        public Nullable<decimal> AverageSpend;
        public string StatusList; // US1769

        public  int no_OfDaysPlayed;// = 0;
        public int no_OfSessionPlayed;// = 0;
        public DateTime gamingDate;
        public int sessionNumber;// = 0;
        public string DaysOfWeek;// = string.Empty;
    }

    /// <summary>
    /// Represents a Get Player List Report server message.
    /// </summary>
    internal class GetPlayerListReportMessage : ServerMessage
    {
        #region Constants and Data Types
        protected const int MinResponseMessageLength = 6;
        #endregion

        #region Member Variables
        protected PlayerListParams m_params;
        protected List<PlayerExportItem> m_playerList = new List<PlayerExportItem>();
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the GetPlayerListReportMessage 
        /// class.
        /// </summary>
        /// <param name="operatorId">The id of the operator who's players to 
        /// search.</param>
        /// <param name="parameters">The player search criteria to be sent to 
        /// the server.</param>
        public GetPlayerListReportMessage(PlayerListParams parameters)
        {
            m_id = 8032; // Get Player List Report
            m_strMessageName = "Get Player List Report";
            m_params = parameters;
        }
        #endregion

        #region Member Methods
        /// <summary>
        /// Prepares the request to be sent to the server.
        /// </summary>
        protected override void PackRequest()
        {
            // Create the streams we will be writing to.
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);

            string invalidDate = new DateTime(1900, 1, 1).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            string tempDate;

            // From Birthday
            if (m_params.FromBirthday != DateTime.MinValue)
                tempDate = m_params.FromBirthday.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            else
                tempDate = invalidDate;

            requestWriter.Write((ushort)tempDate.Length);
            requestWriter.Write(tempDate.ToCharArray());

            // To Birthday
            if (m_params.ToBirthday != DateTime.MinValue)
                tempDate = m_params.ToBirthday.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            else
                tempDate = invalidDate;

            requestWriter.Write((ushort)tempDate.Length);
            requestWriter.Write(tempDate.ToCharArray());

            // Gender
            if (!string.IsNullOrEmpty(m_params.Gender))
            {
                requestWriter.Write((ushort)m_params.Gender.Length);
                requestWriter.Write(m_params.Gender.ToCharArray());
            }
            else
                requestWriter.Write((ushort)0);

            string tempDec;
            // Min Points
            tempDec = m_params.MinPoints.ToString("N", CultureInfo.InvariantCulture);
            requestWriter.Write((ushort)tempDec.Length);
            requestWriter.Write(tempDec.ToCharArray());

            // Max Points
            tempDec = m_params.MaxPoints.ToString("N", CultureInfo.InvariantCulture);
            requestWriter.Write((ushort)tempDec.Length);
            requestWriter.Write(tempDec.ToCharArray());

            //string PBOptionSelected
            if (!string.IsNullOrEmpty(m_params.PBOptionSelected))
            {
                requestWriter.Write((ushort)m_params.PBOptionSelected.Length);
                requestWriter.Write(m_params.PBOptionSelected.ToCharArray());
            }
            else
            {
                requestWriter.Write((ushort)0);
            }

            //decimal PBOptionValue
            tempDec = m_params.PBOptionValue.ToString("N", CultureInfo.InvariantCulture);
            requestWriter.Write((ushort)tempDec.Length);
            requestWriter.Write(tempDec.ToCharArray());

            // From Last Visit
            if (m_params.FromLastVisit != DateTime.MinValue)
                tempDate = m_params.FromLastVisit.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            else
                tempDate = invalidDate;

            requestWriter.Write((ushort)tempDate.Length);
            requestWriter.Write(tempDate.ToCharArray());

            // To Last Visit
            if (m_params.ToLastVisit != DateTime.MinValue)
                tempDate = m_params.ToLastVisit.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            else
                tempDate = invalidDate;

            requestWriter.Write((ushort)tempDate.Length);
            requestWriter.Write(tempDate.ToCharArray());

            // Use Spend
            requestWriter.Write(m_params.UseSpend);

            // Use Average Spend
            requestWriter.Write(m_params.UseAverageSpend);

            // From Spend
            tempDec = m_params.FromSpend.ToString("N", CultureInfo.InvariantCulture);
            requestWriter.Write((ushort)tempDec.Length);
            requestWriter.Write(tempDec.ToCharArray());

            // To Spend
            tempDec = m_params.ToSpend.ToString("N", CultureInfo.InvariantCulture);
            requestWriter.Write((ushort)tempDec.Length);
            requestWriter.Write(tempDec.ToCharArray());

            // From Spend Date
            if (m_params.FromSpendDate != DateTime.MinValue)
                tempDate = m_params.FromSpendDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            else
                tempDate = invalidDate;

            requestWriter.Write((ushort)tempDate.Length);
            requestWriter.Write(tempDate.ToCharArray());

            // To Spend Date
            if (m_params.ToSpendDate != DateTime.MinValue)
                tempDate = m_params.ToSpendDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            else
                tempDate = invalidDate;

            requestWriter.Write((ushort)tempDate.Length);
            requestWriter.Write(tempDate.ToCharArray());

            // bool SAOption
            requestWriter.Write(m_params.SAOption);

            //string SAOptionSelected 
            if (!string.IsNullOrEmpty(m_params.SAOptionSelected))
            {
                requestWriter.Write((ushort)m_params.SAOptionSelected.Length);
                requestWriter.Write(m_params.SAOptionSelected.ToCharArray());
            }
            else
            {
                requestWriter.Write((ushort)0);
            }

            //decimal SAOptionValue
            tempDec = m_params.SAOptionValue.ToString("N", CultureInfo.InvariantCulture);
            requestWriter.Write((ushort)tempDec.Length);
            requestWriter.Write(tempDec.ToCharArray());

            // Status
            if (m_params.UseStatus)
            {
                requestWriter.Write((ushort)m_params.Status.Length);
                requestWriter.Write(m_params.Status.ToCharArray());
            }
            else
            {
                requestWriter.Write((ushort)0);
            }

            // LocationType
            requestWriter.Write(m_params.LocationType);

            //LocationDefinition
            if (!string.IsNullOrEmpty(m_params.LocationDefinition))
            {
                requestWriter.Write((ushort)m_params.LocationDefinition.Length);
                requestWriter.Write(m_params.LocationDefinition.ToCharArray());
            }
            else
            {
                requestWriter.Write((ushort)0);
            }
            
            //ISNumberOfDaysPlayed
            requestWriter.Write(m_params.IsNumberOfdDaysPlayed);

            //bool IsNumberOfSessionPlayed
            requestWriter.Write(m_params.IsNumberOfSessionPlayed);


            //DateTime DPDateRangeFrom
            if (m_params.DPDateRangeFrom != DateTime.MinValue)
            {
                tempDate = m_params.DPDateRangeFrom.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                tempDate = invalidDate;
            }
            requestWriter.Write((ushort)tempDate.Length);
            requestWriter.Write(tempDate.ToCharArray());

            //DateTime DPDateRangeTo
            if (m_params.DPDateRangeTo != DateTime.MinValue)
            {
                tempDate = m_params.DPDateRangeTo.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                tempDate = invalidDate;
            }
            requestWriter.Write((ushort)tempDate.Length);
            requestWriter.Write(tempDate.ToCharArray());

            // bool ISDPRange
            requestWriter.Write(m_params.IsDPRange);

            //string DPRangeFrom Min Days Played 
       
            
                if (!string.IsNullOrEmpty(m_params.DPRangeFrom)) 
            {
                requestWriter.Write(Int32.Parse(m_params.DPRangeFrom));
                
            }
            else
            {
                requestWriter.Write((Int32)0); 
            }

            //string DPRangeTo Max Days Played
            if (!string.IsNullOrEmpty(m_params.DPRangeTo))
            {

                requestWriter.Write(Int32.Parse(m_params.DPRangeTo));
            }
            else
            {
                requestWriter.Write((Int32)0);  
            }
            //bool ISDPOption
            requestWriter.Write(m_params.IsDPOption);

            //string DPOptionSelected
            if (!string.IsNullOrEmpty(m_params.DPOptionSelected))
            {
                requestWriter.Write((ushort)m_params.DPOptionSelected.Length);
                requestWriter.Write(m_params.DPOptionSelected.ToCharArray()); 
            }else
            {
                requestWriter.Write((ushort)0);
            }

            //string DPOptionValue Days Played Option Value

            if (!string.IsNullOrEmpty(m_params.DPOptionValue))
            {

                requestWriter.Write(Int32.Parse(m_params.DPOptionValue));
            }
            else
            {
                requestWriter.Write((Int32)0);
            }
            //requestWriter.Write(Int32.Parse(m_params.DPOptionValue));
 
            //bool IsSPrange Use Session Played Range
            requestWriter.Write(m_params.IsSPRange);  

            //string SPRangeFrom Min Sessions Played
          //  requestWriter.Write(Int32.Parse(m_params.SPRangeFrom));
            if (!string.IsNullOrEmpty(m_params.SPRangeFrom))
            {

                requestWriter.Write(Int32.Parse(m_params.SPRangeFrom));
            }
            else
            {
                requestWriter.Write((Int32)0);
            }

            //string SPRangeTo Max Sessions Played
            //requestWriter.Write(Int32.Parse(m_params.SPRangeTo));
            if (!string.IsNullOrEmpty(m_params.SPRangeTo))
            {

                requestWriter.Write(Int32.Parse(m_params.SPRangeTo));
            }
            else
            {
                requestWriter.Write((Int32)0);
            }

            //bool IsSPOption
            requestWriter.Write(m_params.IsSPOption);
 
            //string SPOptionSelected 
            if (!string.IsNullOrEmpty(m_params.SPOptionSelected))
            {
                requestWriter.Write((ushort)m_params.SPOptionSelected.Length);
                requestWriter.Write(m_params.SPOptionSelected.ToCharArray());     
            }
            else
            {
                requestWriter.Write((ushort)0);  
            }

            //string SPOptionValue 
            //requestWriter.Write(Int32.Parse(m_params.SPOptionValue));            
            if (!string.IsNullOrEmpty(m_params.SPOptionValue))
            {

                requestWriter.Write(Int32.Parse(m_params.SPOptionValue));
            }
            else
            {
                requestWriter.Write((Int32)0);
            }

            //string DaysOfWeekAndSession
            if (!string.IsNullOrEmpty(m_params.DaysOFweekAndSession))
            {
                requestWriter.Write((ushort)m_params.DaysOFweekAndSession.Length);
                requestWriter.Write(m_params.DaysOFweekAndSession.ToCharArray()); 
            }
            else
            {
                requestWriter.Write((ushort)0); 
            }

            //bool IsProduct
            requestWriter.Write(m_params.IsProduct);
            
            //string SelecteProduct
            if (!string.IsNullOrEmpty(m_params.SelectedProduct))
            {   
                requestWriter.Write((ushort)m_params.SelectedProduct.Length);
                requestWriter.Write(m_params.SelectedProduct.ToCharArray()); 
            }
            else
            {
                requestWriter.Write((ushort)0);  
            }

            //Age option selected
            if (!string.IsNullOrEmpty(m_params.AgeOptionSelected))
            {
                requestWriter.Write((ushort)m_params.AgeOptionSelected.Length);
                requestWriter.Write(m_params.AgeOptionSelected.ToCharArray());
            }
            else
            {
                requestWriter.Write((ushort)0);
            }

            //Age
            requestWriter.Write(m_params.Age);

            // Set the bytes to be sent.
            m_requestPayload = requestStream.ToArray();

            // Close the streams.
            requestWriter.Close();
        }

        /// <summary>
        /// Parses the response received from the server.
        /// </summary>
        protected override void UnpackResponse()
        {
            // Clear the array.
            m_playerList.Clear();

            base.UnpackResponse();

            // Create the streams we will be reading from.
            MemoryStream responseStream = new MemoryStream(m_responsePayload);
            BinaryReader responseReader = new BinaryReader(responseStream, Encoding.Unicode);

            // Check the response length.
            if(responseStream.Length < MinResponseMessageLength)
                throw new MessageWrongSizeException(m_strMessageName);

            // Try to unpack the data.
            try
            {
                // Seek past return code.
                responseReader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);

                // Get the count of players.
                ushort playerCount = responseReader.ReadUInt16();

                // Get all the players
                for(ushort x = 0; x < playerCount; x++)
                {
                    PlayerExportItem item = new PlayerExportItem();
                    item.Player = new Player();

                    // Player Id
                    item.Player.Id = responseReader.ReadInt32();

                     //First Name
                    ushort stringLen = responseReader.ReadUInt16();
                    item.Player.FirstName = new string(responseReader.ReadChars(stringLen));

                    // Middle Initial
                    stringLen = responseReader.ReadUInt16();
                    item.Player.MiddleInitial = new string(responseReader.ReadChars(stringLen));

                    // Last Name
                    stringLen = responseReader.ReadUInt16();
                    item.Player.LastName = new string(responseReader.ReadChars(stringLen));

                    // Birth Date
                    stringLen = responseReader.ReadUInt16();
                    string tempDate = new string(responseReader.ReadChars(stringLen));

                    if(!string.IsNullOrEmpty(tempDate))
                        item.Player.BirthDate = DateTime.Parse(tempDate, CultureInfo.InvariantCulture);

                    // Email
                    stringLen = responseReader.ReadUInt16();
                    item.Player.Email = new string(responseReader.ReadChars(stringLen));

                    // Gender
                    stringLen = responseReader.ReadUInt16();
                    item.Player.Gender = new string(responseReader.ReadChars(stringLen));

                    // Address 1
                    stringLen = responseReader.ReadUInt16();
                    item.Player.Address1 = new string(responseReader.ReadChars(stringLen));

                    // Address 2
                    stringLen = responseReader.ReadUInt16();
                    item.Player.Address2 = new string(responseReader.ReadChars(stringLen));

                    // City
                    stringLen = responseReader.ReadUInt16();
                    item.Player.City = new string(responseReader.ReadChars(stringLen));

                    // State
                    stringLen = responseReader.ReadUInt16();
                    item.Player.State = new string(responseReader.ReadChars(stringLen));

                    // Country
                    stringLen = responseReader.ReadUInt16();
                    item.Player.Country = new string(responseReader.ReadChars(stringLen));

                    // Zip
                    stringLen = responseReader.ReadUInt16();
                    item.Player.Zip = new string(responseReader.ReadChars(stringLen));

                    // Refundable Credit
                    stringLen = responseReader.ReadUInt16();
                    string tempDec = new string(responseReader.ReadChars(stringLen));

                    if(!string.IsNullOrEmpty(tempDec))
                        item.Player.RefundableCredit = decimal.Parse(tempDec, CultureInfo.InvariantCulture);

                    // Non-Refundable Credit
                    stringLen = responseReader.ReadUInt16();
                    tempDec = new string(responseReader.ReadChars(stringLen));

                    if(!string.IsNullOrEmpty(tempDec))
                        item.Player.NonRefundableCredit = decimal.Parse(tempDec, CultureInfo.InvariantCulture);

                    // Last Visit Date
                    stringLen = responseReader.ReadUInt16();
                    tempDate = new string(responseReader.ReadChars(stringLen));

                    if(!string.IsNullOrEmpty(tempDate))
                        item.Player.LastVisit = DateTime.Parse(tempDate, CultureInfo.InvariantCulture);

                    // Points Balance
                    stringLen = responseReader.ReadUInt16();
                    tempDec = new string(responseReader.ReadChars(stringLen));

                    if(!string.IsNullOrEmpty(tempDec))
                        item.Player.PointsBalance = decimal.Parse(tempDec, CultureInfo.InvariantCulture);

                    // Total Spend
                    stringLen = responseReader.ReadUInt16();
                    tempDec = new string(responseReader.ReadChars(stringLen));

                    if(!string.IsNullOrEmpty(tempDec))
                        item.Player.TotalSpend = decimal.Parse(tempDec, CultureInfo.InvariantCulture);
            

                    // Average Spend
                    stringLen = responseReader.ReadUInt16();
                    tempDec = new string(responseReader.ReadChars(stringLen));
       
                   if(!string.IsNullOrEmpty(tempDec))
                        item.AverageSpend = decimal.Parse(tempDec, CultureInfo.InvariantCulture);
                   if (string.IsNullOrEmpty(tempDec))
                   {
                       item.AverageSpend = null;
                   }

                    // Visit Count
                    item.Player.VisitCount = responseReader.ReadInt32();

                    // Rally US493
                    // US1769
                    // Status List
                    stringLen = responseReader.ReadUInt16();
                    item.StatusList = new string(responseReader.ReadChars(stringLen));

                    // operatorid
                    int temp = responseReader.ReadInt32();

                    // Government Issued Id Number
                    stringLen = responseReader.ReadUInt16();
                    item.Player.GovIssuedIdNumber = new string(responseReader.ReadChars(stringLen));

                    // Player Identity
                    stringLen = responseReader.ReadUInt16();
                    item.Player.PlayerIdentity = new string(responseReader.ReadChars(stringLen));

                    // Phone Number
                    stringLen = responseReader.ReadUInt16();
                    item.Player.PhoneNumber = new string(responseReader.ReadChars(stringLen));

                    // Join Date
                    stringLen = responseReader.ReadUInt16();
                    tempDate = new string(responseReader.ReadChars(stringLen));

                    if(!string.IsNullOrEmpty(tempDate))
                        item.Player.JoinDate = DateTime.Parse(tempDate, CultureInfo.InvariantCulture);

                    //// Comment
                    stringLen = responseReader.ReadUInt16();
                    item.Player.Comment = new string(responseReader.ReadChars(stringLen));

                    // Mag. Card Number
                    stringLen = responseReader.ReadUInt16();
                    item.Player.MagneticCardNumber = new string(responseReader.ReadChars(stringLen));

                    //No of days Played
                    item.no_OfDaysPlayed = responseReader.ReadInt32();

                    //No of Session Played
                    item.no_OfSessionPlayed = responseReader.ReadInt32();

                    //Gaming Date
                    stringLen = responseReader.ReadUInt16();
                    tempDate = new string(responseReader.ReadChars(stringLen));
                    if (!string.IsNullOrEmpty(tempDate))
                    {
                        item.gamingDate = DateTime.Parse(tempDate, CultureInfo.InvariantCulture);    
                    }

                    //Session Number
                    item.sessionNumber = responseReader.ReadInt32();

                    //days
                    stringLen = responseReader.ReadUInt16();
                    item.DaysOfWeek = new string(responseReader.ReadChars(stringLen));    
              
                    m_playerList.Add(item);
                }
            }
            catch(EndOfStreamException e)
            {
                throw new MessageWrongSizeException(m_strMessageName, e);
            }
            catch(Exception e)
            {
                throw new ServerException(m_strMessageName, e);
            }

            // Close the streams.
            responseReader.Close();
        }
        #endregion

        #region Member Properties
        /// <summary>
        /// Gets or sets the player search criteria to be sent to the server.
        /// </summary>
        public PlayerListParams Parameters
        {
            get
            {
                return m_params;
            }
            set
            {
                m_params = value;
            }
        }

        /// <summary>
        /// Gets an array of players recieved from the server.
        /// </summary>
        public PlayerExportItem[] Players
        {
            get
            {
                return m_playerList.ToArray();
            }
        }
        #endregion
    }
}
