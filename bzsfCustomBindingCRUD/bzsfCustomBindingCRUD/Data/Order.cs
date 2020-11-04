using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bzsfCustomBindingCRUD.Data
{
    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public double Freight { get; set; }
    }
}
