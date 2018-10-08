using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTI.Modules.PlayerCenter
{
    public class DataRafflePrizes
    {
        public int RaffleID;
        public string RaffleName;
        public int NoOfRafflePrize;
        public string RafflePrizeDescription;
        public string RaffleDisclaimer;
        public int RaffleHistoryID;
        //public bool IsEnable;


        public int gsRaffleHistoryID
        {
            get { return RaffleHistoryID; }
            set { gsRaffleHistoryID = value; }
        }

        public int gsRaffleID
        {
            get {return RaffleID;}
            set { RaffleID = value; }
        }

        public string gsRaffleName
        {
            get { return RaffleName; }
            set { RaffleName = value; }
        }

        public int gsNoOfRafflePrize
        {
            get { return NoOfRafflePrize; }
            set { NoOfRafflePrize = value; }
        }

        public string gsRafflePrizeDescription
        {
            get { return RafflePrizeDescription; }
            set { RafflePrizeDescription = value; }
        }

        public string gsRaffleDisclaimer
        {
            get { return RaffleDisclaimer; }
            set { RaffleDisclaimer = value; }
        }
        //public bool gsIsEnable
        //{
        //    get { return IsEnable; }
        //    set { IsEnable = value; }
        //}

    }

    public class List_DataRafflePrize
    {
        public static List<DataRafflePrizes> LDataRafflePrize = new List<DataRafflePrizes>();
    }
}
