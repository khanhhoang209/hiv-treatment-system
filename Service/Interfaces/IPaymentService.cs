namespace Service.Interfaces;

public interface IPaymentService
{
    Task<string> CreateOrderAsync(decimal amount, Guid userId, Guid doctorId, Guid medicalRecordId);
}