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
        public VariantAttributeDTO Attribute { get; set; }
        public VariantAttributeValueDTO Value { get; set; }
        public DateTime Created_On { get; set; }
        public List<StockDTO> Stocks { get; set; }
    }
}
