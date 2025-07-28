namespace Service.Interfaces;

public interface IPayPalService
{
    Task<string> CreateOrderAsync(decimal amount);
}