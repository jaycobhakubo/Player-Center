using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTI.Modules.Shared.Business;

namespace GTI.Modules.PlayerCenter.Data
{



    //public class GetPlayerTierRulesData
    //{
    //    public static TierRulesData getPlayerTierRulesData = new TierRulesData();
    //}


    public class GetPlayerTierData
    {
        public static List<TierData> getPlayerTierData = new List<TierData>();
    }

    public class SetPlayerTierRulesData
    {
        public static TierRule setPlayerTierRulesData = new TierRule(); 
    }

    public class SetTiersData
    {
        public static TierData tiersData = new TierData();
    }



    public class TierData
    {
        public int TierID {get;set;}//(int (4-bytes))
        public int TierRulesID { get; set; }//(int(4-bytes))
        public string TierName { get; set; }//()
        public int TierColor { get; set; }//(int(4-bytes))
        public decimal AmntSpend { get; set; } //Amount Spend what would you be??? //Let us try decimal instead of string
        public decimal NbrPoints { get; set; } //Same as AmntSpend  Number of Points 
        public decimal Multiplier { get; set; } //nvarchar(Points Multiplier Len)) 
        public bool isdelete { get; set; }


        public override bool Equals(object obj)
        {
            var other = obj as TierData;

            if (other == null)
                return false;

            if (
                TierID != other.TierID ||
                TierName != other.TierName || //!TierName.Equals(other.TierName, StringComparison.InvariantCultureIgnoreCase)||
                TierColor != other.TierColor ||
                AmntSpend != other.AmntSpend ||
                NbrPoints != other.NbrPoints ||
                Multiplier != other.Multiplier ||
                isdelete != other.isdelete
                )
            {

                return false;
            }
            return true;
        }

    }


    //public class TierRulesData
    //{
    //    public int TierRulesID; //(int(4-bytes))
    //    public int DefaultTierID; //(int(4-bytes))
    //    public bool DowngradeToDefault;//(byte(1 byte))
    //    public DateTime QualifyingStartDate; //(nvarchar(Qualifying Start Date Len))
    //    public DateTime QualifyingEndDate;//(nvarchar(Qualifying End Date Len))
    //}
}
