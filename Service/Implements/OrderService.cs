using Repository.Interfaces;
using Repository.Models;
using Service.Interfaces;

namespace Service.Implements;

public class OrderService : IOrderService 
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<decimal> CalculateTotalPriceAsync(Guid medicalRecordId)
    {
        return await _orderRepository.CalculateTotalPriceAsync(medicalRecordId);
    }
    public async Task CreateAsync(Order order)
    {
        await _orderRepository.CreateAsync(order);
    }
    public async Task<Order?> GetOrderByIdAsync(Guid orderId)
    {
        return await _orderRepository.GetOrderByIdAsync(orderId);
    }
    public async Task<List<Order>> GetOrdersByUserIdAsync(Guid userId)
    {
        return await _orderRepository.GetOrdersByUserIdAsync(userId);
    }
    public async Task<List<Order>> GetAllOrdersAsync()
    {
        return await _orderRepository.GetAllOrdersAsync();
    }
    public async Task<bool> GetOrderByMedicalRecordId(Guid medicalRecordId)
    {
        return await _orderRepository.GetOrderByMedicalRecordId(medicalRecordId);
    }
    
}