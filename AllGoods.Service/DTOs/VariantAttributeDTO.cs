using AllGoods.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGoods.Service.DTOs
{
    public class VariantAttributeDTO
    {
        public int AttributeID { get; set; }
        public string? Name { get; set; }
        public List<VariantDTO>? Variants { get; set; }
        public List<VariantAttributeValueDTO>? Values { get; set; }
    }
}
