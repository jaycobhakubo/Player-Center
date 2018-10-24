﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTI.Modules.PlayerCenter.Data
{



    public class GetPlayerTierRulesData
    {
        public static TierRulesData getPlayerTierRulesData = new TierRulesData();
    }


    public class GetPlayerTierData
    {
        public static List<TierData> getPlayerTierData = new List<TierData>();
    }

    public class SetPlayerTierRulesData
    {
        public static TierRulesData setPlayerTierRulesData = new TierRulesData(); 
    }

    public class SetTiersData
    {
        public static TierData tiersData = new TierData();
    }



    public class TierData
    {
        public int TierID;//(int (4-bytes))
        public int TierRulesID;//(int(4-bytes))
        public string TierName;//()
        public int TierColor;//(int(4-bytes))
        public decimal AmntSpend; //Amount Spend what would you be??? //Let us try decimal instead of string
        public decimal NbrPoints; //Same as AmntSpend  Number of Points 
        public decimal Multiplier; //nvarchar(Points Multiplier Len)) 
        public bool isdelete;
    }


    public class TierRulesData
    {
        public int TierRulesID; //(int(4-bytes))
        public int DefaultTierID; //(int(4-bytes))
        public bool DowngradeToDefault;//(byte(1 byte))
        public DateTime QualifyingStartDate; //(nvarchar(Qualifying Start Date Len))
        public DateTime QualifyingEndDate;//(nvarchar(Qualifying End Date Len))

    }
}