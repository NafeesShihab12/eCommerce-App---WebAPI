using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGoods.Repository.Models
{
    public class Warehouse
    {
        public int WarehouseID { get; set; }
        public string Name { get; set; }
        public ICollection<Stock> Stocks { get; set; }
    }
}
