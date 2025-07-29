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

namespace Application.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly IOrderService _service;

        public IndexModel(IOrderService service)
        {
            _service = service;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var account = HttpContext.Session.GetString("Account");
            if (string.IsNullOrEmpty(account))
            {
                return RedirectToPage("/Login");
            }
            var role = HttpContext.Session.GetString("Role");
            if (role == "Admin")
            {
                Order = await _service.GetAllOrdersAsync();
            }
            else if(role == "User")
            {
                Order = await _service.GetOrdersByUserIdAsync(Guid.Parse(account));
            }
            return Page();
        }
        
    }
}
