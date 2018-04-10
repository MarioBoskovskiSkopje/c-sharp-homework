using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class VendorItems
    {
        public List<string> VendorItemsList;
        public VendorItems()
        {
            VendorItemsList = new List<string>();
            VendorItemsList.Add("VW");
            VendorItemsList.Add("Audi");
            VendorItemsList.Add("Bmw");

        }
        
    }
}
