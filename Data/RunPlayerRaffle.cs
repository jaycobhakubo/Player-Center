using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GTI.Modules.Shared;

namespace GTI.Modules.PlayerCenter.Data
{
    public class RaffleWinner
    {
        public int HistoryID { get; set; }
        public int RaffleDefID { get; set; }
        public int PlayerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    /// <summary>
    /// The possible status return codes from the Run Player Raffle 
    /// server message.
    /// </summary>
    public enum RunPlayerRaffleReturnCode
    {
        NotEnoughPlayers = 1,
        RaffleInProgress = 3
    }

    /// <summary>
    /// Represents a Run Player Raffle server message.
    /// </summary>
    public class RunPlayerRaffleMessage : ServerMessage
    {
        #region Member Variables
        private RaffleWinner m_winner;
        private int m_raffleId;
        private int m_raffleHistoryId;
        private int m_rafflePlayerListId;
        #endregion

        #region Cosntructors
        /// <summary>
        /// Message to run a player raffle
        /// </summary>
        /// <param name="raffleId">The ID of the raffle to run</param>
        /// <param name="raffleHistoryId">the ID of the previous raffle that ran. 0 if none</param>
        /// <param name="playerListId">The player list to run the raffle over</param>
        public RunPlayerRaffleMessage(int raffleId, int raffleHistoryId, int playerListId)
        {
            m_id = 18035;
            m_raffleId = raffleId;
            m_raffleHistoryId = raffleHistoryId;
            m_rafflePlayerListId = playerListId;
            m_winner = new RaffleWinner();
            m_winner.RaffleDefID = m_raffleId;
        }

        /// <summary>
        /// Message to run a player raffle
        /// </summary>
        /// <param name="raffleId">The ID of the raffle to run</param>
        /// <param name="raffleHistoryId">the ID of the previous raffle that ran. 0 if none</param>
        /// <param name="playerListId">The player list to run the raffle over</param>
        /// <returns>The winner of the raffle</returns>
        public static RaffleWinner GetRaffleWinner(int raffleId, int raffleHistoryId, int playerListId)
        {
            RunPlayerRaffleMessage msg = new RunPlayerRaffleMessage(raffleId, raffleHistoryId, playerListId);
            try
            {
                msg.Send();
            }
            catch (ServerCommException ex)
            {
                throw new Exception("RunPlayerRaffle: " + ex.Message);
            }

            return msg.m_winner;
        }
        #endregion

        #region Member Methods
        protected override void PackRequest()
        {
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);

            requestWriter.Write(m_raffleId);
            requestWriter.Write(m_raffleHistoryId);
            requestWriter.Write(m_rafflePlayerListId);

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
                // Seek past return code.
                responseReader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);

                if (ReturnCode == 0)
                {
                    m_winner = new RaffleWinner();
                    // Raffle History Id
                    m_winner.HistoryID = responseReader.ReadInt32();
                    // Player Id
                    m_winner.PlayerID = responseReader.ReadInt32();
                    // Player First Name
                    m_winner.FirstName = ReadString(responseReader);
                    // Player Last Name
                    m_winner.LastName = ReadString(responseReader);
                }
            }
            catch (EndOfStreamException e)
            {
                throw new MessageWrongSizeException("Run Player Raffle", e);
            }
            catch (Exception e)
            {
                throw new ServerException("Run Player Raffle", e);
            }

            responseReader.Close();
        }
        #endregion
    }
}
