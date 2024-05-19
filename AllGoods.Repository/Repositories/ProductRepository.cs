using AllGoods.Repository.Context;
using AllGoods.Repository.Interfaces;
using AllGoods.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace AllGoods.Repository.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ECommerceContext _context;
        public ProductRepository(ECommerceContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Product> GetProductBySEONameAsync(string seoName)
        {
            return await _context.Set<Product>()
                .Include(p => p.Variants)
                    .ThenInclude(v => v.Stocks)
                .FirstOrDefaultAsync(p => p.SEOName == seoName);
        }

        public async Task<IEnumerable<Product>> GetProductsFilteredAsync(ProductFilter filter)
        {
            var query = _context.Set<Product>()
                .Include(p => p.Variants)
                    .ThenInclude(v => v.Stocks)
                .AsQueryable();

            if (filter.InStock.HasValue)
            {
                query = filter.InStock.Value ?
                    query.Where(p => p.Variants.Any(v => v.Stocks.Any(s => s.Quantity > 0))) :
                    query.Where(p => !p.Variants.Any(v => v.Stocks.Any(s => s.Quantity > 0)));
            }

            if (!string.IsNullOrEmpty(filter.Variant))
            {
                query = query.Where(p => p.Variants.Any(v => v.VariantAttributeValue.Value == filter.Variant));
            }

            if (filter.WarehouseId.HasValue)
            {
                query = query.Where(p => p.Variants.Any(v => v.Stocks.Any(s => s.WarehouseID == filter.WarehouseId)));
            }

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(p => p.Name.Contains(filter.Name));
            }

            if (!string.IsNullOrEmpty(filter.SortBy))
            {
                switch (filter.SortBy.ToLower())
                {
                    case "createdon":
                        query = filter.Ascending ? query.OrderBy(p => p.Variants.FirstOrDefault().Created_On) : query.OrderByDescending(p => p.Variants.FirstOrDefault().Created_On);
                        break;
                    case "cumulativestock":
                        query = filter.Ascending ?
                            query.OrderBy(p => p.Variants.Sum(v => v.Stocks.Sum(s => s.Quantity))) :
                            query.OrderByDescending(p => p.Variants.Sum(v => v.Stocks.Sum(s => s.Quantity)));
                        break;
                    default:
                        break;
                }
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Set<Product>()
                .Include(p => p.Variants)
                    .ThenInclude(v => v.Stocks)
                .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _context.Set<Product>()
                .Include(p => p.Variants)
                    .ThenInclude(v => v.Stocks)
                .FirstOrDefaultAsync(p => p.ProductID == productId);
        }

        public async Task<int> UpdateProductStockAsync(int productId, int variantId, int warehouseId, int quantity)
        {
            var stock = await _context.Set<Stock>().FirstOrDefaultAsync(s => s.VariantID == variantId && s.WarehouseID == warehouseId);
            if (stock != null)
            {
                stock.Quantity += quantity;
                return await _context.SaveChangesAsync();
            }
            return 0;
        }
    }
}
