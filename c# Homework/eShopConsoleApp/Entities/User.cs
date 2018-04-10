using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public string Name { get; set; }
        public List<OrderItem> Orders;
        public User(string name)
        {
            Name = name;
        }
        public User()
        {
            Orders = new List<OrderItem>();
        }
    }
}
