using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Models;
using Service.Interfaces;

namespace Application.Pages.MedicalRecords
{
    public class DetailsModel : PageModel
    {
        private readonly IMedicalRecordService _medicalRecordService;
        private readonly IPaymentService _paymentService;
        private readonly IOrderService _orderService;
        public DetailsModel(IMedicalRecordService medicalRecordService,
            IPaymentService paymentService,
            IOrderService orderService)
        {
            _paymentService = paymentService;
            _medicalRecordService = medicalRecordService;
            _orderService = orderService;
        }

        public MedicalRecord MedicalRecord { get; set; } = default!;
        public decimal TotalPrice { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            var role = HttpContext.Session.GetString("Role");
            if (id == null)
            {
                return NotFound();
            }

            var medicalrecord = await _medicalRecordService.GetMedicalRecordDetail(id.Value);
            if (medicalrecord == null)
            {
                return NotFound();
            }
           
   
            MedicalRecord = medicalrecord;
            if (role == "User")
            {
                TotalPrice = await _orderService.CalculateTotalPriceAsync(medicalrecord.Id);
            }

            return Page();
        }
        public async Task<IActionResult> OnPostCreatePaypalOrderAsync(Guid doctorId, Guid medicalRecordId, decimal totalPrice)
        {
            var account = HttpContext.Session.GetString("Account");
            var role = HttpContext.Session.GetString("Role");
            if (string.IsNullOrEmpty(account))
            {
                return RedirectToPage("/Login");
            }
            if (role != "User")
            {
                return RedirectToPage("/Index");
            }
            var approvalUrl = await _paymentService.CreateOrderAsync(totalPrice, 
                                          Guid.Parse(account), doctorId, medicalRecordId);
            return Redirect(approvalUrl); // redirect sang PayPal 
        }
    }
}
