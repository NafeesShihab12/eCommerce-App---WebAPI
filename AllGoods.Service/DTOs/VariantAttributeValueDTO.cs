using AllGoods.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGoods.Service.DTOs
{
    public class VariantAttributeValueDTO
    {
        public int ValueID { get; set; }
        public int AttributeID { get; set; }
        public string? Value { get; set; }
        public VariantAttribute? VariantAttribute { get; set; }
        public List<VariantDTO>? Variants { get; set; }
    }
}
