using AllGoods.Repository.Context;
using AllGoods.Repository.Interfaces;
using AllGoods.Repository.Models;
using AllGoods.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGoods.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceContext _context;
        private Repository<Product> _products;
        private Repository<Warehouse> _warehouses;
        private Repository<Stock> _stocks;
        private Repository<Order> _orders;
        private Repository<OrderItem> _orderItems;
        private Repository<VariantAttribute> _variantAttributes;
        private Repository<VariantAttributeValue> _variantAttributeValues;
        private Repository<Variant> _variants;

        public UnitOfWork(ECommerceContext context)
        {
            _context = context;
        }

        public IRepository<Product> Products => _products ??= new Repository<Product>(_context);
        public IRepository<Warehouse> Warehouses => _warehouses ??= new Repository<Warehouse>(_context);
        public IRepository<Stock> Stocks => _stocks ??= new Repository<Stock>(_context);
        public IRepository<Order> Orders => _orders ??= new Repository<Order>(_context);
        public IRepository<OrderItem> OrderItems => _orderItems ??= new Repository<OrderItem>(_context);
        public IRepository<VariantAttribute> VariantAttributes => _variantAttributes ??= new Repository<VariantAttribute>(_context);
        public IRepository<VariantAttributeValue> VariantAttributeValues => _variantAttributeValues ??= new Repository<VariantAttributeValue>(_context);
        public IRepository<Variant> Variants => _variants ??= new Repository<Variant>(_context);

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
