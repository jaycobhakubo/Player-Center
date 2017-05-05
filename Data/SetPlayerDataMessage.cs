#region Copyright
// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2008 GameTech
// International, Inc.
#endregion

using System;
using System.IO;
using System.Text;
using System.Globalization;
using GTI.Modules.Shared;
using GTI.Modules.PlayerCenter.Business;
using GTI.Modules.PlayerCenter.Properties;

namespace GTI.Modules.PlayerCenter.Data
{
    /// <summary>
    /// Represents the Set Player Data server message.
    /// </summary>
    internal class SetPlayerDataMessage : ServerMessage
    {
        #region Constants and Data Types
        protected const int ResponseMessageLength = 8;
        #endregion

        #region Member Variables
        protected int m_playerId = 0;
        protected string m_firstName = string.Empty;
        protected string m_middleInitial = string.Empty;
        protected string m_lastName = string.Empty;
        protected string m_govIssuedIdNum = string.Empty;
        protected DateTime m_birthDate;
        protected string m_email = string.Empty;
        protected string m_playerIdent = string.Empty;
        protected string m_phoneNum = string.Empty;
        protected string m_gender = string.Empty;
        protected byte[] m_pinNum; // Rally TA1583
        protected string m_address1 = string.Empty;
        protected string m_address2 = string.Empty;
        protected string m_city = string.Empty;
        protected string m_state = string.Empty;
        protected string m_zip = string.Empty;
        protected string m_country = string.Empty;
        protected DateTime m_joinDate;
        protected DateTime m_lastVisit;
        protected decimal m_pointsBalance = 0M;
        protected int m_visitCount = 0;
        protected string m_comment = string.Empty;
        protected string m_magCardNum = string.Empty;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the SetPlayerDataMessage class.
        /// </summary>
        public SetPlayerDataMessage()
        {
            m_id = 8010; // Set Player Data
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

            // Player Id
            requestWriter.Write(m_playerId);

            // First Name
            requestWriter.Write((ushort)m_firstName.Length);
            requestWriter.Write(m_firstName.ToCharArray());

            // Middle Initial
            requestWriter.Write((ushort)m_middleInitial.Length);
            requestWriter.Write(m_middleInitial.ToCharArray());

            // Last Name
            requestWriter.Write((ushort)m_lastName.Length);
            requestWriter.Write(m_lastName.ToCharArray());

            // Gov. Issued Id Number
            requestWriter.Write((ushort)m_govIssuedIdNum.Length);
            requestWriter.Write(m_govIssuedIdNum.ToCharArray());

            // Birth Date
            string tempDate = string.Empty;

            if(m_birthDate != DateTime.MinValue)
                tempDate = m_birthDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

            requestWriter.Write((ushort)tempDate.Length);
            requestWriter.Write(tempDate.ToCharArray());

            // Email
            requestWriter.Write((ushort)m_email.Length);
            requestWriter.Write(m_email.ToCharArray());

            // Player Ident
            requestWriter.Write((ushort)m_playerIdent.Length);
            requestWriter.Write(m_playerIdent.ToCharArray());

            // Phone #
            requestWriter.Write((ushort)m_phoneNum.Length);
            requestWriter.Write(m_phoneNum.ToCharArray());

            // Gender
            requestWriter.Write((ushort)m_gender.Length);
            requestWriter.Write(m_gender.ToCharArray());

            // Rally TA1583
            // Pin #
            byte[] hashBuffer = new byte[DataSizes.PasswordHash];

            if(m_pinNum != null)
                Array.Copy(m_pinNum, hashBuffer, DataSizes.PasswordHash);

            requestWriter.Write(hashBuffer);

            // Address 1
            requestWriter.Write((ushort)m_address1.Length);
            requestWriter.Write(m_address1.ToCharArray());

            // Address 2
            requestWriter.Write((ushort)m_address2.Length);
            requestWriter.Write(m_address2.ToCharArray());

            // City
            requestWriter.Write((ushort)m_city.Length);
            requestWriter.Write(m_city.ToCharArray());

            // State
            requestWriter.Write((ushort)m_state.Length);
            requestWriter.Write(m_state.ToCharArray());

            // Zip
            requestWriter.Write((ushort)m_zip.Length);
            requestWriter.Write(m_zip.ToCharArray());

            // Country
            requestWriter.Write((ushort)m_country.Length);
            requestWriter.Write(m_country.ToCharArray());

            // Join Date
            tempDate = string.Empty;

            if(m_joinDate != DateTime.MinValue)
                tempDate = m_joinDate.ToString("MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            requestWriter.Write((ushort)tempDate.Length);
            requestWriter.Write(tempDate.ToCharArray());

            // Last Visit
            tempDate = string.Empty;

            if(m_lastVisit != DateTime.MinValue)
                tempDate = m_lastVisit.ToString("MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            requestWriter.Write((ushort)tempDate.Length);
            requestWriter.Write(tempDate.ToCharArray());

            // Points Balance
            string tempDec = m_pointsBalance.ToString("N", CultureInfo.InvariantCulture);
            requestWriter.Write((ushort)tempDec.Length);
            requestWriter.Write(tempDec.ToCharArray());

            // Visit Count
            requestWriter.Write(m_visitCount);

            // Comment
            requestWriter.Write((ushort)m_comment.Length);
            requestWriter.Write(m_comment.ToCharArray());

            // Mag. Card
            requestWriter.Write((ushort)m_magCardNum.Length);
            requestWriter.Write(m_magCardNum.ToCharArray());

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
            base.UnpackResponse();

            // Create the streams we will be reading from.
            MemoryStream responseStream = new MemoryStream(m_responsePayload);
            BinaryReader responseReader = new BinaryReader(responseStream, Encoding.Unicode);

            // Check the response length.
            if(responseStream.Length != ResponseMessageLength)
                throw new MessageWrongSizeException("Set Player Data");

            // Try to unpack the data.
            try
            {
                // Seek past return code.
                responseReader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);

                // Player Id
                m_playerId = responseReader.ReadInt32();
            }
            catch(EndOfStreamException e)
            {
                throw new MessageWrongSizeException("Set Player Data", e);
            }
            catch(Exception e)
            {
                throw new ServerException("Set Player Data", e);
            }

            // Close the streams.
            responseReader.Close();
        }
        #endregion

        #region Member Properties
        /// <summary>
        /// Gets or sets the id of the player.
        /// </summary>
        public int PlayerId
        {
            get
            {
                return m_playerId;
            }
            set
            {
                m_playerId = value;
            }
        }

        /// <summary>
        /// Gets or sets the player's first name.
        /// </summary>
        public string FirstName
        {
            get
            {
                return m_firstName;
            }
            set
            {
                if(value.Length <= StringSizes.MaxNameLength)
                    m_firstName = value;
                else
                    throw new ArgumentException("FirstName is too big.");
            }
        }

        /// <summary>
        /// Gets or sets the player's middle initial.
        /// </summary>
        public string MiddleInitial
        {
            get
            {
                return m_middleInitial;
            }
            set
            {
                if(value.Length <= StringSizes.MaxMiddleNameLength)
                    m_middleInitial = value;
                else
                    throw new ArgumentException("MiddleInitial is too big.");
            }
        }

        /// <summary>
        /// Gets or sets the player's last name.
        /// </summary>
        public string LastName
        {
            get
            {
                return m_lastName;
            }
            set
            {
                if(value.Length <= StringSizes.MaxNameLength)
                    m_lastName = value;
                else
                    throw new ArgumentException("LastName is too big.");
            }
        }

        /// <summary>
        /// Gets or sets the player's gov. issued id number.
        /// </summary>
        public string GovIssuedIdNumber
        {
            get
            {
                return m_govIssuedIdNum;
            }
            set
            {
                if(value.Length <= StringSizes.MaxGovIssuedIdNumLength)
                    m_govIssuedIdNum = value;
                else
                    throw new ArgumentException("GovIssuedIdNumber is too big.");
            }
        }

        /// <summary>
        /// Gets or sets the player's birth date.
        /// </summary>
        public DateTime BirthDate
        {
            get
            {
                return m_birthDate;
            }
            set
            {
                m_birthDate = value;
            }
        }

        /// <summary>
        /// Gets or sets the player's email address.
        /// </summary>
        public string Email
        {
            get
            {
                return m_email;
            }
            set
            {
                if(value.Length <= StringSizes.MaxEmailLength)
                    m_email = value;
                else
                    throw new ArgumentException("Email is too big.");
            }
        }

        /// <summary>
        /// Gets or sets a custom player id string.
        /// </summary>
        public string PlayerIdentity
        {
            get
            {
                return m_playerIdent;
            }
            set
            {
                if(value.Length <= StringSizes.MaxPlayerIdentLength)
                    m_playerIdent = value;
                else
                    throw new ArgumentException("PlayerIdentity is too big.");
            }
        }

        /// <summary>
        /// Gets or sets the player's phone number.
        /// </summary>
        public string PhoneNumber
        {
            get
            {
                return m_phoneNum;
            }
            set
            {
                if(value.Length <= StringSizes.MaxPhoneNumberLength)
                    m_phoneNum = value;
                else
                    throw new ArgumentException("PhoneNumber is too big.");
            }
        }

        /// <summary>
        /// Gets or sets the player's gender.
        /// </summary>
        public string Gender
        {
            get
            {
                return m_gender;
            }
            set
            {
                if(value.Length <= StringSizes.MaxGenderLength)
                    m_gender = value;
                else
                    throw new ArgumentException("Gender is too big.");
            }
        }

        /// <summary>
        /// Gets or sets the player's pin number.
        /// </summary>
        public byte[] PinNumber
        {
            get
            {
                return m_pinNum;
            }
            set
            {
                if(value != null && value.Length != DataSizes.PasswordHash)
                    throw new ArgumentException("PinNumber is the wrong size.");

                m_pinNum = value;
            }
        }

        /// <summary>
        /// Gets or sets the player's address line 1.
        /// </summary>
        public string Address1
        {
            get
            {
                return m_address1;
            }
            set
            {
                if(value.Length <= StringSizes.MaxAddressLength)
                    m_address1 = value;
                else
                    throw new ArgumentException("Address1 is too big.");
            }
        }

        /// <summary>
        /// Gets or sets the player's address line 2.
        /// </summary>
        public string Address2
        {
            get
            {
                return m_address2;
            }
            set
            {
                if(value.Length <= StringSizes.MaxAddressLength)
                    m_address2 = value;
                else
                    throw new ArgumentException("Address2 is too big.");
            }
        }

        /// <summary>
        /// Gets or sets the player's city.
        /// </summary>
        public string City
        {
            get
            {
                return m_city;
            }
            set
            {
                if(value.Length <= StringSizes.MaxCityStateZipCountryLength)
                    m_city = value;
                else
                    throw new ArgumentException("City is too big.");
            }
        }

        /// <summary>
        /// Gets or sets the player's state.
        /// </summary>
        public string State
        {
            get
            {
                return m_state;
            }
            set
            {
                if(value.Length <= StringSizes.MaxCityStateZipCountryLength)
                    m_state = value;
                else
                    throw new ArgumentException("State is too big.");
            }
        }

        /// <summary>
        /// Gets or sets the player's zip.
        /// </summary>
        public string Zip
        {
            get
            {
                return m_zip;
            }
            set
            {
                if(value.Length <= StringSizes.MaxCityStateZipCountryLength)
                    m_zip = value;
                else
                    throw new ArgumentException("Zip is too big.");
            }
        }

        /// <summary>
        /// Gets or sets the player's country.
        /// </summary>
        public string Country
        {
            get
            {
                return m_country;
            }
            set
            {
                if(value.Length <= StringSizes.MaxCityStateZipCountryLength)
                    m_country = value;
                else
                    throw new ArgumentException("Country is too big.");
            }
        }

        /// <summary>
        /// Gets or sets the player's join date.
        /// </summary>
        public DateTime JoinDate
        {
            get
            {
                return m_joinDate;
            }
            set
            {
                m_joinDate = value;
            }
        }

        /// <summary>
        /// Gets or sets the player's last visit.
        /// </summary>
        public DateTime LastVisit
        {
            get
            {
                return m_lastVisit;
            }
            set
            {
                m_lastVisit = value;
            }
        }

        /// <summary>
        /// Gets or sets the player's point balance.
        /// </summary>
        public decimal PointsBalance
        {
            get
            {
                return m_pointsBalance;
            }
            set
            {
                // Check to make sure it's not too big to fit in a string.
                string tempDec = value.ToString("N", CultureInfo.InvariantCulture);

                if(tempDec.Length <= StringSizes.MaxDecimalLength)
                    m_pointsBalance = value;
                else
                    throw new ArgumentException("PointsBalance is too big.");
            }
        }

        /// <summary>
        /// Gets or sets the player's visit count.
        /// </summary>
        public int VisitCount
        {
            get
            {
                return m_visitCount;
            }
            set
            {
                m_visitCount = value;
            }
        }

        /// <summary>
        /// Gets or sets the player's comment.
        /// </summary>
        public string Comment
        {
            get
            {
                return m_comment;
            }
            set
            {
                if(value.Length <= StringSizes.MaxPlayerCommentLength)
                    m_comment = value;
                else
                    throw new ArgumentException("Comment is too big.");
            }
        }

        /// <summary>
        /// Gets or sets a player's mag. card number.
        /// </summary>
        public string MagCardNumber
        {
            get
            {
                return m_magCardNum;
            }
            set
            {
                if(value.Length <= StringSizes.MaxMagneticCardLength)
                    m_magCardNum = value;
                else
                    throw new ArgumentException("MagCardNumber is too big.");
            }
        }
        #endregion
    }
}
