using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTI.Modules.PlayerCenter.Data
{
    public class RaffleSetting
    {
        public int RaffleSettingID { get; set; }//globalsetting ID
        public string RaffleSettingValue { get; set; }
    }

    public class RaffleSettings
    {
        public static List<RaffleSetting> data = new List<RaffleSetting>();
    }

}
