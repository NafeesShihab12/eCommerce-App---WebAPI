using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGoods.Repository.Models
{
    public class VariantAttribute
    {
        public int AttributeID { get; set; }
        public string? Name { get; set; }
        public ICollection<Variant>? Variants { get; set; }
        public ICollection<VariantAttributeValue>? Values { get; set; }
    }
}
