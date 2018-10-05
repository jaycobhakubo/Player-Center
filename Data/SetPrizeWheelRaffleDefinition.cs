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
    /// Represents a message to update or create a new prize wheel raffle
    /// </summary>
    public class SetPrizeWheelRaffleDefinition : ServerMessage
    {
        #region Private Members

        private WheelRaffle m_raffle;
        private bool m_delete;

        #endregion

        #region Public Properties

        public WheelRaffle Raffle
        {
            get { return m_raffle; }
            set
            {
                m_raffle = value;
            }
        }
        public bool DeleteRaffle
        {
            get { return m_delete; }
            set
            {
                m_delete = value;
            }
        }

        #endregion

        public SetPrizeWheelRaffleDefinition(WheelRaffle raffle, bool delete)
        {
            m_id = 18246;
            m_strMessageName = "Set Prize Wheel Raffle Definition";

            m_raffle = raffle;
            m_delete = delete;
        }

        #region Member Methods

        /// <summary>
        /// Updates the sent in prize wheel raffle. Returns the ID of the prize wheel raffle that was edited, the wheel image ID, and the overlay ID
        /// </summary>
        /// <param name="raffle"></param>
        /// <param name="delete"></param>
        /// <returns></returns>
        public static Tuple<int,int,int> SetPrizeWheelRaffle(WheelRaffle raffle, bool delete = false)
        {
            var msg = new SetPrizeWheelRaffleDefinition(raffle, delete);
            try
            {
                msg.Send();
            }
            catch (ServerCommException ex)
            {
                throw new Exception(msg.MessageName + " Message: " + ex.Message);
            }

            return new Tuple<int, int, int>(msg.Raffle.ID.Value, msg.m_raffle.WheelPhotoId.Value, msg.m_raffle.OverlayPhotoId.Value);
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

                requestWriter.Write(Raffle.ID ?? 0);

                requestWriter.Write(m_delete);

                WriteString(requestWriter, m_raffle.Name);

                WriteString(requestWriter, m_raffle.Description);

                requestWriter.Write((ushort)(m_raffle.Options == null? 0 : m_raffle.Options.Count));
                if (m_raffle.Options != null)
                {
                    foreach (var option in m_raffle.Options)
                    {
                        WriteString(requestWriter, option.Prize);
                        requestWriter.Write(option.Weight);
                    }
                }

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

                    Raffle.ID = reader.ReadInt32();
                    Raffle.WheelPhotoId = reader.ReadInt32();
                    Raffle.OverlayPhotoId = reader.ReadInt32();
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
