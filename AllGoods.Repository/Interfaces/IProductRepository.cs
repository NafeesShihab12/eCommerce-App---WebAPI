using AllGoods.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGoods.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetProductBySEONameAsync(string seoName);
        Task<IEnumerable<Product>> GetProductsFilteredAsync(ProductFilter filter);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);
        Task<int> UpdateProductStockAsync(int productId, int variantId, int warehouseId, int quantity);

    }
}
