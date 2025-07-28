namespace Repository.Interfaces;

public interface IOrderRepository
{
    Task<decimal> CalculateTotalPriceAsync(Guid medicalRecordId);

}