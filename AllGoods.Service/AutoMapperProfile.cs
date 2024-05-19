using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllGoods.Repository.Models;
using AllGoods.Service.DTOs;
using AutoMapper;

namespace AllGoods.Service
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<Variant, VariantDTO>();
            CreateMap<VariantAttribute, VariantAttributeDTO>();
            CreateMap<VariantAttributeValue, VariantAttributeValueDTO>();
            CreateMap<Stock, StockDTO>();
            CreateMap<Warehouse, WarehouseDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderItem, OrderItemDTO>();
            CreateMap<ProductFilter, ProductFilterDTO>();
        }

    }
}
