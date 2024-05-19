using AllGoods.Repository.Interfaces;
using AllGoods.Repository.Models;
using AllGoods.Service.DTOs;
using AllGoods.Service.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using StackExchange.Redis;

namespace AllGoods.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IDatabase _redisCache;

        public ProductService(IProductRepository productRepository, IMapper mapper, IMemoryCache memoryCache, IConnectionMultiplexer redisConnection)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
            _redisCache = redisConnection.GetDatabase();
        }

        public async Task<ProductDTO> GetProductBySEONameAsync(string seoName)
        {
            string cacheKey = $"product_seo_{seoName}";

            // Try getting the product from memory cache
            if (!_memoryCache.TryGetValue(cacheKey, out ProductDTO productDto))
            {
                // Try getting the product from Redis cache
                var redisValue = await _redisCache.StringGetAsync(cacheKey);
                if (redisValue.HasValue)
                {
                    productDto = System.Text.Json.JsonSerializer.Deserialize<ProductDTO>(redisValue);
                }
                else
                {
                    // Get product from the repository
                    var product = await _productRepository.GetProductBySEONameAsync(seoName);
                    if (product == null)
                    {
                        return null;
                    }

                    productDto = _mapper.Map<ProductDTO>(product);

                    // Store in Redis cache
                    await _redisCache.StringSetAsync(cacheKey, System.Text.Json.JsonSerializer.Serialize(productDto));

                    // Store in memory cache
                    _memoryCache.Set(cacheKey, productDto);
                }
            }

            return productDto;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsFilteredAsync(ProductFilterDTO filterDTO)
        {
            var filter = _mapper.Map<ProductFilter>(filterDTO);
            var products = await _productRepository.GetProductsFilteredAsync(filter);
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetProductByIdAsync(int productId)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<int> UpdateProductStockAsync(int productId, int variantId, int warehouseId, int quantity)
        {
            return await _productRepository.UpdateProductStockAsync(productId, variantId, warehouseId, quantity);
        }
    }
}
