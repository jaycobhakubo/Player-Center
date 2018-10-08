#region Copyright
// This is an unpublished work protected under the copyright laws of the United
// States and other countries.  All rights reserved.  Should publication occur
// the following will apply:  © 2008-2017 GameTech International, Inc.
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTI.Modules.Shared;
using System.IO;

namespace GTI.Modules.PlayerCenter.Data
{
    /// <summary>
    /// Represents a message to the server that tells it to run the sent in prize wheel raffle and returns the result
    /// </summary>
    public class RunPrizeWheelRaffle : ServerMessage
    {
        #region Private Members

        private int m_raffleID;
        private string m_win;

        #endregion

        #region Public Properties

        public int RaffleID
        {
            get { return m_raffleID; }
            set
            {
                m_raffleID = value;
            }
        }

        public string Win
        {
            get { return m_win; }
            set
            {
                m_win = value;
            }
        }

        #endregion

        public RunPrizeWheelRaffle(int id)
        {
            m_id = 18247;
            m_strMessageName = "Run Prize Wheel Raffle";

            m_raffleID = id;
        }

        #region Member Methods

        /// <summary>
        /// Runs the sent in raffle and returns the resulting win
        /// </summary>
        /// <param name="gamingDate"></param>
        /// <returns></returns>
        public static string RunRaffle(int id)
        {
            var msg = new RunPrizeWheelRaffle(id);
            try
            {
                msg.Send();
            }
            catch (ServerCommException ex)
            {
                throw new Exception(msg.MessageName + " Message: " + ex.Message);
            }

            return msg.Win;
        }

        /// <summary>
        /// Prepares the request to be sent to the server.
        /// </summary>
        protected override void PackRequest()
        {
            // Create the streams we will be writing to.
            using (var requestStream = new MemoryStream())
            using (var requestWriter = new BinaryWriter(requestStream, Encoding.Unicode))
            {
                //Drawing ID
                requestWriter.Write(m_raffleID);

                // Set the bytes to be sent.
                m_requestPayload = requestStream.ToArray();

                // Close the streams.
                requestWriter.Close();
            }
        }

        /// <summary>
        /// Parses the response received from the server.
        /// </summary>
        protected override void UnpackResponse()
        {
            base.UnpackResponse();

            // Create the streams we will be reading from.
            using (var responseStream = new MemoryStream(m_responsePayload))
            using (var reader = new BinaryReader(responseStream, Encoding.Unicode))
            {
                // Try to unpack the data.
                try
                {
                    // Seek past return code.
                    reader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);

                    Win = ReadString(reader);
                }
                catch (EndOfStreamException e)
                {
                    throw new MessageWrongSizeException(m_strMessageName, e);
                }
                catch (Exception e)
                {
                    throw new ServerException(m_strMessageName, e);
                }
            }
        }
        #endregion
    }
}
