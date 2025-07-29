using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Models;
using Service.Interfaces;

namespace Application.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeService _employeeService;
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;

        public EditModel(IEmployeeService employeeService, IRoleService roleService, IUserService userService)
        {
            _employeeService = employeeService;
            _roleService = roleService;
            _userService = userService;
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee =  await _employeeService.GetEmployeeByIdAsync(id.Value);
            if (employee == null)
            {
                return NotFound();
            }
            Employee = employee;
            ViewData["UserId"] = new SelectList(_userService.GetAllEmployees(), "Id", "Email");
            ViewData["RoleId"] = new SelectList(_roleService.GetRoles(), "Id", "Name");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var roleId = new Guid(Request.Form["Employee.User.Role.Id"]!);

            try
            {
                await _employeeService.UpdateAsync(Employee, roleId);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(Employee.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EmployeeExists(Guid id)
        {
            return _employeeService.GetEmployeeByIdAsync(id) != null!;
        }
    }
}