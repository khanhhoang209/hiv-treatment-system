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
        private readonly IPrescriptionService _prescriptionService;

        public IndexModel(IMedicalRecordService medicalRecordService, IPrescriptionService prescriptionService)
        {
            _medicalRecordService = medicalRecordService;
            _prescriptionService = prescriptionService;
        }

        public IList<MedicalRecord> MedicalRecord { get;set; } = default!;
        public bool HasPrescription { get; set; }
        public async Task OnGetAsync()
        {
 
            var role = HttpContext.Session.GetString("Role");
            var account = HttpContext.Session.GetString("Account");

            if (role == "Admin")
            {
                MedicalRecord =  await _medicalRecordService.GetMedicalRecordsAsync();
            } 
            if(role == "Doctor")
            {
                MedicalRecord = await _medicalRecordService.GetMedicalRecordsAsync();
            }
            if (role == "User")
            {
                MedicalRecord = await _medicalRecordService.GetMedicalRecordsByUserIdAsync(Guid.Parse(account!));
            }
            var idString = HttpContext.Session.GetString("MedicalRecordId");
            if (Guid.TryParse(idString, out var medicalRecordId))
            {
                HasPrescription =
                    await _prescriptionService.GetPrescriptionByMedicalRecordId(medicalRecordId);
            }
        }
    }
}
