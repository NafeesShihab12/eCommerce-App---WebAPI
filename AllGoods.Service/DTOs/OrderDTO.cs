using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGoods.Service.DTOs
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
