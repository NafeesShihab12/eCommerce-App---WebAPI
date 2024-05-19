using AllGoods.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGoods.Service.DTOs
{
    public class VariantDTO
    {
        public int VariantID { get; set; }
        public int ProductID { get; set; }
        public Product? Product { get; set; }
        public int AttributeID { get; set; }
        public VariantAttribute? VariantAttribute { get; set; }
        public int ValueID { get; set; }
        public VariantAttributeValue? VariantAttributeValue { get; set; }
        public DateTime Created_On { get; set; }
        public List<StockDTO>? Stocks { get; set; }
        public List<OrderItemDTO>? OrderItems { get; set; }
    }
}
