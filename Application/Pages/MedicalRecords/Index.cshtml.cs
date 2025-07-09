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
    public class IndexModel : PageModel
    {
        private readonly IMedicalRecordService _medicalRecordService;

        public IndexModel(IMedicalRecordService medicalRecordService)
        {
            _medicalRecordService = medicalRecordService;
        }

        public IList<MedicalRecord> MedicalRecord { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role == "Admin")
            {
                MedicalRecord = await _medicalRecordService.GetAllMedicalRecords();
            }
            else if(role == "Doctor")
            {
                var account = HttpContext.Session.GetString("Account");
                MedicalRecord = await _medicalRecordService.GetAllMedicalRecords();
            }
            else
            {
                var account = HttpContext.Session.GetString("Account");
                MedicalRecord = await _medicalRecordService.GetMedicalRecordsByUserId(Guid.Parse(account));
            }
        }
    }
}
