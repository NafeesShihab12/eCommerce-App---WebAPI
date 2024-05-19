using AllGoods.Repository.Models;
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
        public string? CustomerName { get; set; }
        public int OrderItemID { get; set; }
        public OrderItem? OrderItem { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
