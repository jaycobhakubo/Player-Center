using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTI.Modules.PlayerCenter.Data
{


    //Set GetPlayerTierRulesData
    //public class GetPlayerTierRulesData
    //{
    //    public static TierRulesData getPlayerTierRulesData = new TierRulesData();
    //}

    //public class SetPlayerTierRulesData
    //{
    //    public static TierRulesData setPlayerTierRulesData = new TierRulesData(); 
    //}

    public class TierRulesData
    {
        public int TierRulesID; //(int(4-bytes))
        public int DefaultTierID; //(int(4-bytes))
        public bool DowngradeToDefault;//(byte(1 byte))
        public DateTime QualifyingStartDate; //(nvarchar(Qualifying Start Date Len))
        public DateTime QualifyingEndDate;//(nvarchar(Qualifying End Date Len))

    }
}
