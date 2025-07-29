using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Models;
using Service.Interfaces;

namespace Application.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;


        public CreateModel(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public IActionResult OnGet()
        {
            ViewData["UserId"] = new SelectList(_userService.GetAllEmployees(), "Id", "Email");
            ViewData["RoleId"] = new SelectList(_roleService.GetRoles(), "Id", "Name");

            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var userId = Guid.NewGuid();
            var user = new ApplicationUser()
            {
                Id = userId,
                Username = Employee.FirstName + " " + Employee.LastName,
                Password = Password,
                Email = Employee.Email,
                Phone = Employee.Phone,
                Address = Employee.Address,
                DateOfBirth = Employee.DateOfBirth,
                Gender = Employee.Gender,
                Status = "Active",
                RoleId = Employee.User.Role.Id,
                Employees = new List<Employee>()
                {
                    new Employee
                    {
                        Id = Guid.NewGuid(),
                        FirstName = Employee.FirstName,
                        LastName = Employee.LastName,
                        Email = Employee.Email,
                        Phone = Employee.Phone,
                        Address = Employee.Address,
                        DateOfBirth = Employee.DateOfBirth,
                        Gender = Employee.Gender,
                        Status = Employee.Status,
                        UserId = userId,
                    }
                }
            };

            await _userService.CreateUser(user);


            return RedirectToPage("./Index");
        }
    }
}