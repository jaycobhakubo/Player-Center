#region Copyright
// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2008 GameTech
// International, Inc.
#endregion

using System;
using System.IO;
using System.Text;
using GTI.Modules.Shared;

namespace GTI.Modules.PlayerCenter.Data
{
    /// <summary>
    /// Represents a ClearPlayerRaffle server message.
    /// </summary>
    public class ClearPlayerRaffleMessage : ServerMessage
    {
        #region Cosntructors
        /// <summary>
        /// Initializes a new instance of the ClearPlayerRaffleMessage class.
        /// </summary>
        public ClearPlayerRaffleMessage()
        {
            m_id = 18036; // Clear Player Raffle
        }
        #endregion

        #region Member Methods
        /// <summary>
        /// Prepares the request to be sent to the server.
        /// </summary>        
        protected override void PackRequest()
        {
        }
        #endregion
    }
}
