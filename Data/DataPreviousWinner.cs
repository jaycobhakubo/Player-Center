using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTI.Modules.PlayerCenter.Data
{
    public class DataPreviousWinner
    {
        public int RaffleID { get; set; }
        public string RaffleName { get; set; }
        public List<int> WinnerPlayerID = new List<int>();
        public List<string> WinnerPlayerFName = new List<string>();
        public List<string> WinnerPlayerLName = new List<string>();
        
    }

    public class ListPreviousWinner
    {
        public static List<DataPreviousWinner> data = new List<DataPreviousWinner>();
    }

}
