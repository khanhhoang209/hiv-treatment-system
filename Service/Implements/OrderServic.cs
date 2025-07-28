using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Implements;

public class OrderServic : IOrderService 
{
    private readonly IOrderRepository _orderRepository;

    public OrderServic(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<decimal> CalculateTotalPriceAsync(Guid medicalRecordId)
    {
        return await _orderRepository.CalculateTotalPriceAsync(medicalRecordId);
    }
}