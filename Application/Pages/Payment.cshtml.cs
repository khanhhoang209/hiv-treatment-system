using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Models;
using Service.Interfaces;

namespace Application.Pages;

public class Payment : PageModel
{
    private readonly IPaymentService _paypal;
    private readonly IOrderService _orderService;
    public Payment(IPaymentService paypal, IOrderService orderService)
    {
        _orderService = orderService;
        _paypal = paypal;
    }
    public string Message { get; set; }

    public async Task<IActionResult> OnGetAsync(string? status, Guid? doctorId, Guid? medicalRecordId, decimal? totalPrice)
    {
        var userId = HttpContext.Session.GetString("Account");
        if (string.IsNullOrEmpty(userId))
        {
            return RedirectToPage("/Login");
        }
        if (status == "success")
        {
            if (doctorId.HasValue && medicalRecordId.HasValue && totalPrice.HasValue)
            {
                var order = new Order
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.Parse(userId),
                    DoctorId = doctorId.Value,
                    MedicalRecordId = medicalRecordId.Value,
                    TotalPrice = totalPrice.Value,
                    CreateAt = DateTime.Now
                };
                
                var existedOrders = await _orderService.GetOrdersByUserIdAsync(Guid.Parse(userId));
                bool alreadyCreated = existedOrders.Any(o =>
                    o.DoctorId == doctorId &&
                    o.MedicalRecordId == medicalRecordId &&
                    Math.Abs(o.TotalPrice - totalPrice.Value) < (decimal)0.01 &&
                    (DateTime.Now - o.CreateAt).TotalMinutes < 5); // chỉ cho tạo lại nếu đã quá lâu

                if (!alreadyCreated)
                {
                    await _orderService.CreateAsync(order);
                    TempData["PaymentSuccess"] = "Thanh toán thành công!";
    
                    return RedirectToPage("/Orders/Details", new { id = order.Id });
                }
                else
                {
                    TempData["PaymentSuccess"] = "Đơn hàng đã tồn tại gần đây.";
                    return RedirectToPage("/Orders/Index");
                }

            }
            return RedirectToPage("/Orders/Details/", new { id = medicalRecordId });
        }
        if (status == "cancel")
        {
            TempData["PaymentCancelled"] = "Thanh toán đã bị hủy.";
            return RedirectToPage("/Orders/Index");
        }

        return Page();
    }

    
    public async Task<IActionResult> OnPostAsync(Guid doctorId, Guid medicalRecordId)
    {
        var userIdStr = HttpContext.Session.GetString("Account");
        if (string.IsNullOrEmpty(userIdStr) || !Guid.TryParse(userIdStr, out var userId))
        {
            return RedirectToPage("/Login");
        }
        
        decimal amount = await _orderService.CalculateTotalPriceAsync(medicalRecordId);
        
        string redirectUrl = await _paypal.CreateOrderAsync(amount, userId, doctorId, medicalRecordId);
        return Redirect(redirectUrl);
    }

}