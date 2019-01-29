﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace GTI.Modules.Shared.Business
{
    public class Tier
    {
       

        private int m_tierId;
        private string m_tierName;
        private bool m_isDefaultTier;
  

        public override bool Equals(object obj)
        {
            var other = obj as Tier;

            if (other == null)
                return false;

            if (
                TierID != other.TierID ||
                TierName != other.TierName || //!TierName.Equals(other.TierName, StringComparison.InvariantCultureIgnoreCase)||
                TierColor != other.TierColor ||
                QualifyingSpend != other.QualifyingSpend ||
                QualifyingPoints != other.QualifyingPoints ||
                AwardPointsMultiplier != other.AwardPointsMultiplier ||
                IsDelete != other.IsDelete
                )
            {

                return false;
            }
            return true;
        }

        public override string ToString()
        {
            string t_tierName = "";
            t_tierName = (IsDefaultTier == true) ?  m_tierName + " (default)" : m_tierName;
            return t_tierName;
        }

        public int TierID //(int (4-bytes))
        {
            get { return m_tierId; }
            set { m_tierId = value; }
        }
        public int TierRulesID { get; set; }//(int(4-bytes))
        public string TierName
        {
            get 
            {
                return m_tierName;
            }
            set 
            { 
                m_tierName = value; 
            }
        }
        public int TierColor { get; set; }//(int(4-bytes))
        public decimal QualifyingSpend { get; set; } //Amount Spend what would you be??? //Let us try decimal instead of string
        public decimal QualifyingPoints { get; set; } //Same as AmntSpend  Number of Points 
        public decimal AwardPointsMultiplier { get; set; } //nvarchar(Points AwardPointsMultiplier Len)) 
        public bool IsDelete { get; set; }
        public int TierIconId { get; set; }
        public bool IsDefaultTier 
        { 
            get 
            {
                return m_isDefaultTier;
            }
            set 
            {
                m_isDefaultTier = value;
            } 
        }

       
    }

    public class TierRule
    {
        public int TierRulesID { get; set; } 
        public int DefaultTierID { get; set; } 
        public bool DowngradeToDefault { get; set; }
        public DateTime QualifyingStartDate { get; set; } 
        public DateTime QualifyingEndDate { get; set; }


        public override bool Equals(object obj)
        {
            var other = obj as TierRule;

            if (other == null)
                return false;

            if (
              DefaultTierID != other.DefaultTierID ||
              DowngradeToDefault != other.DowngradeToDefault ||
              QualifyingStartDate != other.QualifyingStartDate ||
              QualifyingEndDate != other.QualifyingEndDate)
            {
                return false;
            }
            return true;
        }

        public void UpdateValueTierRule(TierRule newTierRule)
        {

        }
    }

    public class TierIcon
    {

        private byte[] m_imgData; 


        public int TierIconId { get; set; }         
        
        public byte[] ImgData 
        {
            get
            {
                return m_imgData;
            }
            set 
            {
                m_imgData = value;
            }
        }
       

        public Image TierIconImage
        {
            get
            {
                MemoryStream mStream = new MemoryStream(m_imgData);
                return Image.FromStream(mStream);
            }
        }
    }
}