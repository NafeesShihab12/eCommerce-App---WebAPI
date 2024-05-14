using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGoods.Repository.Models
{
    public class VariantAttributeValue
    {
        public int ValueID { get; set; }
        public int AttributeID { get; set; }
        public string Value { get; set; }
        public VariantAttribute Attribute { get; set; }
    }
}
