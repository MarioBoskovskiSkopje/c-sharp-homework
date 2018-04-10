using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public delegate void UserNotified(string msg);

    class PaymentEvent
    {
        public PaymentEvent(string msg)
        {
            Msg = msg;
        }

        public string Msg { get; set; }

        private UserNotified _handler;
        public event UserNotified UserNotified
        {
            add
            {
                _handler += value;
            }
            remove
            {
                _handler -= value;
            }
        }

        
    }
}
