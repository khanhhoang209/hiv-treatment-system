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

        public IndexModel(Repository.Context.ApplicationDbContext context, IMedicalRecordService medicalRecordService)
        {
            _medicalRecordService = medicalRecordService;
        }

        public IList<MedicalRecord> MedicalRecord { get;set; } = default!;

        public async Task OnGetAsync()
        {
            MedicalRecord = await _medicalRecordService.GetMedicalRecordsByUserId(Guid.Parse("f0034b9c-7fb1-4cfe-9b84-681a97b40420"));
        }
    }
}
