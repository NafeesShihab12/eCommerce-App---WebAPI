using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGoods.Repository.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string SEOName { get; set; }
        public ICollection<Variant> Variants { get; set; }
    }
}
