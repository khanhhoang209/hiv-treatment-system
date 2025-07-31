using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Context;
using Repository.Models;
using Service.Interfaces;

namespace Application.Pages.MedicalRecords
{
    public class CreateModel : PageModel
    {
        private readonly IMedicalRecordService _medicalRecordService;
        private readonly IDoctorService _doctorService;
        private readonly IEmployeeService _employeeService;
        private readonly IUserService _userService;

        public CreateModel(IMedicalRecordService medicalRecordService, IDoctorService doctorService, IEmployeeService employeeService, IUserService userService)
        {
            _medicalRecordService = medicalRecordService;
            _doctorService = doctorService;
            _employeeService = employeeService;
            _userService = userService;
        }

        public async Task<IActionResult> OnGet()
        {
            var currentUserId = HttpContext.Session.GetString("Account");
            var doctors = _doctorService.GetAllDoctors();
            var doctorList = new List<dynamic>();

            foreach (var doctor in doctors)
            {
                var employee = await _employeeService.GetEmployee(doctor.EmployeeId);
                // var user = await _userService.GetApplicationUserById(employee.UserId);
                if (employee.UserId.ToString() == currentUserId)
                {
                    doctorList.Add(new
                    {
                        Id = doctor.Id,
                        Name = $"{employee.FirstName} {employee.LastName}"
                    });
                    break;
                }
            }

            ViewData["DoctorId"] = new SelectList(doctorList, "Id", "Name");

            var users = await _userService.GetAll();
            var userList = new List<dynamic>();

            foreach (var user in users)
            {
                var search = await _userService.GetApplicationUserById(user.Id);
                userList.Add(new
                {
                    Id = search.Id,
                    Name = $"{search.Username}"
                });
            }

            ViewData["UserId"] = new SelectList(userList, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public MedicalRecord MedicalRecord { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            await _medicalRecordService.CreateMedicalRecord(MedicalRecord);
            return RedirectToPage("./Index");
        }
    }
}
