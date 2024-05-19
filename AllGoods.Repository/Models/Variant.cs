using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGoods.Repository.Models
{
    public class Variant
    {
        public int VariantID { get; set; }
        public int ProductID { get; set; }
        public Product? Product { get; set; }
        public int AttributeID { get; set; }
        public VariantAttribute? VariantAttribute { get; set; }
        public int ValueID { get; set; }
        public VariantAttributeValue? VariantAttributeValue { get; set; }
        public DateOnly Created_On { get; set; }
        public ICollection<Stock>? Stocks { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
