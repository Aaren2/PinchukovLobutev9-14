using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinchukovLobutev9_14.ClassHelper
{
    public class MyDiscount
    {
        public static decimal Discount(decimal price, decimal discount)
        {
            return Math.Round(price - (price * discount),2);
        }
    }
}
