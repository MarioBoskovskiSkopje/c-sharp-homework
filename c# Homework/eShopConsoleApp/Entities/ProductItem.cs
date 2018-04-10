using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProductItem
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int ProductCode { get; set; }
        public ProductItem(string name,int price,int productCode)
        {
            Name = name;
            Price = price;
            ProductCode = productCode;
            
         }

    }
}
