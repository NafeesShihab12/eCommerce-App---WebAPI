using AllGoods.Service.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllGoods.Service.Interfaces
{
    public interface IProductService
    {
        Task<ProductDTO> GetProductBySEONameAsync(string seoName);
        Task<IEnumerable<ProductDTO>> GetProductsFilteredAsync(ProductFilterDTO filter);
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> GetProductByIdAsync(int productId);
        Task<int> UpdateProductStockAsync(int productId, int variantId, int warehouseId, int quantity);
    }
}
