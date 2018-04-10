using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OrderItem

    {
        public  ProductItem Product { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public OrderItem(ProductItem product,int quantity,double totalPrice)
        {
            Product = product;
            Quantity = quantity;
            TotalPrice = totalPrice;
        }

    }
}
