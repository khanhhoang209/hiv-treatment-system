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

namespace Application.Pages.MedicalRecords
{
    public class EditModel : PageModel
    {
        private readonly IMedicalRecordService _medicalRecordService;
        private readonly IDoctorService _doctorService;
        private readonly IEmployeeService _employeeService;
        private readonly IUserService _userService;

        public EditModel(IMedicalRecordService medicalRecordService, IDoctorService doctorService, IEmployeeService employeeService, IUserService userService)
        {
            _medicalRecordService = medicalRecordService;
            _doctorService = doctorService;
            _employeeService = employeeService;
            _userService = userService;
        }

        [BindProperty]
        public MedicalRecord MedicalRecord { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
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

            var doctor = await _doctorService.GetDoctor(medicalrecord.DoctorId);
            var employee = await _employeeService.GetEmployee(doctor.EmployeeId);
            var user = await _userService.GetApplicationUserById(medicalrecord.UserId);
            ViewData["DoctorId"] = new SelectList(
    new[] {
        new { Id = doctor.Id, Name = employee.FirstName + " " + employee.LastName }
    },
    "Id",
    "Name",
    doctor.Id
);
            ViewData["UserId"] = new SelectList(new[] {
        new { Id = user.Id, Name = user.Username }
    },
    "Id",
    "Name",
    user.Id);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            try
            {
                await _medicalRecordService.UpdateMedicalRecord(MedicalRecord);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!MedicalRecordExists(MedicalRecord.Id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> MedicalRecordExists(Guid id)
        {
            return await _medicalRecordService.GetMedicalRecordDetail(id) != null;
        }
    }
}
