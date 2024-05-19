using AllGoods.Repository.Interfaces;
using AllGoods.Repository.Models;
using AllGoods.Service.DTOs;
using AllGoods.Service.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AllGoods.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<OrderService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        //public async Task<int> PlaceOrderAsync(OrderDTO orderDto)
        //{
        //    using var transaction = await _unitOfWork.BeginTransactionAsync();

        //    try
        //    {
        //        // Mock payment process
        //        bool paymentSuccessful = MockPaymentProcess();
        //        if (!paymentSuccessful)
        //        {
        //            return -1; // Payment failed
        //        }

        //        var order = _mapper.Map<Order>(orderDto);
        //        await _unitOfWork.OrderRepository.AddAsync(order);
        //        await _unitOfWork.CompleteAsync();

        //        // Update stock quantities
        //        foreach (var item in orderDto.OrderItem.Orders)
        //        {
        //            await _unitOfWork.StockRepository.UpdateStockAsync(item.VariantID, item.Quantity);
        //        }

        //        await _unitOfWork.CompleteAsync();
        //        await transaction.CommitAsync();

        //        return order.OrderID;
        //    }
        //    catch (Exception ex)
        //    {
        //        await transaction.RollbackAsync();
        //        _logger.LogError(ex, "An error occurred while placing the order.");
        //        return -1;
        //    }
        //}

        //private bool MockPaymentProcess()
        //{
        //    // Simulate a payment process
        //    return true; // Assume payment is always successful for this mock
        //}
    }
}
