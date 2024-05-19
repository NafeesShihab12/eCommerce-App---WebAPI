using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGoods.Service.DTOs
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string? Name { get; set; }
        public string? SEOName { get; set; }
        public List<VariantDTO>? Variants { get; set; }
    }
}
