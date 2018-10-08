using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GTI.Modules.PlayerCenter.Data
{
    /// <summary>
    /// The data that encapsulates everything it is to be a prize-wheel raffle
    /// </summary>
    public class WheelRaffle
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
        public List<WheelRafflePrizes> Options
        {
            get;
            set;
        }
        /// <summary>
        /// The ID of the raffle wheel photo
        /// </summary>
        public int? WheelPhotoId
        {
            get;
            set;
        }
        /// <summary>
        /// The raffle wheel image
        /// </summary>
        public Bitmap WheelImage
        {
            get;
            set;
        }
        /// <summary>
        /// The ID of the raffle wheel photo
        /// </summary>
        public int? OverlayPhotoId
        {
            get;
            set;
        }
        /// <summary>
        /// The raffle wheel image
        /// </summary>
        public Bitmap OverlayImage
        {
            get;
            set;
        }

        public WheelRaffle()
        {
            Options = new List<WheelRafflePrizes>();
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
    public class WheelRafflePrizes
    {
        public string Prize
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
            return String.Format("{0,2} chances at {1}", Weight, Prize);
        }
    }
}
