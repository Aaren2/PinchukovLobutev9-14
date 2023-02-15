using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PinchukovLobutev9_14.Db;

namespace PinchukovLobutev9_14.ClassHelper
{
    public class EFClass
    {
        public static Entities context {get;} = new Entities();    
    }
}
