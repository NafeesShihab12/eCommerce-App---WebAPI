using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGoods.Service.DTOs
{
    public class OrderItemDTO
    {
        public int OrderItemID { get; set; }
        public int VariantID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal VariantAmount { get; set; }
    }
}
