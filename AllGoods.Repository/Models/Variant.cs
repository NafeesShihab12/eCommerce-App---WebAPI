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
        public int AttributeID { get; set; }
        public int ValueID { get; set; }
        public DateTime Created_On { get; set; }
        public Product Product { get; set; }
        public VariantAttribute Attribute { get; set; }
        public VariantAttributeValue Value { get; set; }
    }
}
