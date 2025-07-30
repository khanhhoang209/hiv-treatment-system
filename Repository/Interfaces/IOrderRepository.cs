using Repository.Models;

namespace Repository.Interfaces;

public interface IOrderRepository
{
    Task<decimal> CalculateTotalPriceAsync(Guid medicalRecordId);
    
    Task CreateAsync(Order order);
    Task<Order?> GetOrderByIdAsync(Guid orderId);
    Task<List<Order>> GetOrdersByUserIdAsync(Guid userId);
    Task<List<Order>> GetAllOrdersAsync();
    Task<bool> GetOrderByMedicalRecordId(Guid medicalRecordId);
}