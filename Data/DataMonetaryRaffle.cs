using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTI.Modules.PlayerCenter.Data
{
    /// <summary>
    /// The data that encapsulates everything it is to be a monetary raffle
    /// </summary>
    public class MonetaryRaffle
    {
        /// <summary>
        /// The unique ID of the raffle. If null, then this raffle hasn't been saved to the DB yet
        /// </summary>
        public int? ID
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public List<MonetaryRafflePrizes> Options
        {
            get;
            set;
        }

        public MonetaryRaffle()
        {
            Options = new List<MonetaryRafflePrizes>();
        }

        public override string ToString()
        {
            if (Name == null)
                return String.Format("[ID: {0}]", ID);
            return Name;
        }
    }

    /// <summary>
    /// The data that encapsulates everything it is to be an option for the monetary raffle to pay out
    /// </summary>
    public class MonetaryRafflePrizes
    {
        public decimal Value
        {
            get;
            set;
        }
        public int Weight
        {
            get;
            set;
        }

        public override string ToString()
        {
            return String.Format("{0,2} chances at {1,8:F2}", Weight, Value); // left align an pad value to 5 digits
        }
    }
}
