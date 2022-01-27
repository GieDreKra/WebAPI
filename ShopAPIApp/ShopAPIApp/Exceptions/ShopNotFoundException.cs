using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAPIApp.Exceptions
{
    public class ShopNotFoundException : Exception
    {
        public ShopNotFoundException()
        {
        }

        public ShopNotFoundException(string message)
            : base(message)
        {
        }

        public ShopNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
