using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WHouse.Models
{
    public class CustomerView
    {
        public List<Inventory> inventories { get; set; }
        public List<OrderProduct> orderProducts { get; set; }
        public List<CustumerOrder> custumerOrders { get; set; }
    }
}