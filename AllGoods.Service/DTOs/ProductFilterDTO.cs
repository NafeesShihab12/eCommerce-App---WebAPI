using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGoods.Service.DTOs
{
    public class ProductFilterDTO
    {
        public bool? InStock { get; set; }
        public string? Variant { get; set; }
        public int? WarehouseId { get; set; }
        public string? Name { get; set; }
        public string? SortBy { get; set; }
        public bool Ascending { get; set; }
    }
}
