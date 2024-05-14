using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGoods.Service.DTOs
{
    public class StockDTO
    {
        public int StockID { get; set; }
        public int VariantID { get; set; }
        public int WarehouseID { get; set; }
        public int Quantity { get; set; }
    }
}
