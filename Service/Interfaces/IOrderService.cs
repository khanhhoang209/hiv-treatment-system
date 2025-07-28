namespace Service.Interfaces;

public interface IOrderService
{
    Task<decimal> CalculateTotalPriceAsync(Guid medicalRecordId);
}