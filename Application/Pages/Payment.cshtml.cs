using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interfaces;

namespace Application.Pages;

public class Payment : PageModel
{
    private readonly IPayPalService _paypal;
    public string Message { get; set; }

    public void OnGet(string? status)
    {
        if (status == "success")
        {
            Message = "Thanh toán thành công!";
        }
        else if (status == "cancel")
        {
            Message = "Thanh toán đã bị hủy.";
        }
    }

    public Payment(IPayPalService paypal)
    {
        _paypal = paypal;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        string redirectUrl = await _paypal.CreateOrderAsync(500);
        return Redirect(redirectUrl);
    }
}