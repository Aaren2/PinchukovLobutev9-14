using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PinchukovLobutev9_14.ClassHelper
{
    public class Cart
    {

        public static ObservableCollection<Db.Product> Products { get; set; } = new ObservableCollection<Db.Product>();

    }
}
