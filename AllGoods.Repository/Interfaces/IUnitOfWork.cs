using AllGoods.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGoods.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }
        IRepository<Warehouse> Warehouses { get; }
        IRepository<Stock> Stocks { get; }
        IRepository<Order> Orders { get; }
        IRepository<OrderItem> OrderItems { get; }
        IRepository<VariantAttribute> VariantAttributes { get; }
        IRepository<VariantAttributeValue> VariantAttributeValues { get; }
        IRepository<Variant> Variants { get; }
        Task SaveChangesAsync();
        void Dispose();
    }
}
