using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTI.Modules.PlayerCenter.Data
{
    class ProductList
    {
        public int PackageID { get; set; }
        public bool ChargeDeviceFee {get; set;}
        public string PackageName { get; set;} 
        public string ReceiptText { get; set; }
        public string  Packageprice { get; set; }
        public override string ToString()
        {
            return PackageName; 
        }

    }
}
