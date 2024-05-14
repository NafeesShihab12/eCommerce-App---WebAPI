using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGoods.Repository.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
