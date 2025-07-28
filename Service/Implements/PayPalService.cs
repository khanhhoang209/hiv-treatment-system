using Microsoft.Extensions.Configuration;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using Service.Interfaces;

namespace Service.Implements;

public class PayPalService : IPayPalService
{
    private readonly PayPalHttpClient _client;

    public PayPalService(IConfiguration config)
    {
        var environment = new SandboxEnvironment(
            config["PayPal:ClientId"],
            config["PayPal:Secret"]
        );
        _client = new PayPalHttpClient(environment);
    }

    public async Task<string> CreateOrderAsync(decimal amount)
    {
        var orderRequest = new OrderRequest()
        {
            CheckoutPaymentIntent = "CAPTURE",
            PurchaseUnits = new List<PurchaseUnitRequest>
            {
                new PurchaseUnitRequest
                {
                    AmountWithBreakdown = new AmountWithBreakdown
                    {
                        CurrencyCode = "USD",
                        Value = amount.ToString("F2")
                    }
                }
            },
            ApplicationContext = new ApplicationContext
            {
                ReturnUrl = "https://localhost:8000/Payment?status=success",
                CancelUrl = "https://localhost:8000/Payment?status=cancel"
            }
        };

        var request = new OrdersCreateRequest();
        request.Prefer("return=representation");
        request.RequestBody(orderRequest);

        var response = await _client.Execute(request);
        var result = response.Result<Order>();

        return result.Links.First(x => x.Rel == "approve").Href;
    }
}