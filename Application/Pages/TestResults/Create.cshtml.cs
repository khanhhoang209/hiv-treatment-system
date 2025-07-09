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

namespace Application.Pages.TestResults
{
    public class CreateModel : PageModel
    {
        private readonly ITestResultService _testResultService;
        private readonly ITypeService _typeService;
        private readonly IArvService _arvService;
        private readonly IMedicalRecordService _medicalRecordService;

        [BindProperty(SupportsGet = true)]
        public Guid RecordId { get; set; }

        public CreateModel(ITestResultService testResultService, ITypeService typeService, IArvService arvService, IMedicalRecordService medicalRecordService)
        {
            _testResultService = testResultService;
            _typeService = typeService;
            _arvService = arvService;
            _medicalRecordService = medicalRecordService;
        }

        public async Task<IActionResult> OnGet()
        {
            var arvList = await _arvService.GetAllAsync();
            var recordList = await _medicalRecordService.GetMedicalRecordDetail(RecordId);
            var typeList = _typeService.GetAllType();
            ViewData["ArvRegimentId"] = new SelectList(arvList, "Id", "Description");
            //ViewData["MedicalRecordId"] = recordList;
            ViewData["TypeId"] = new SelectList(typeList, "Id", "Description");
            return Page();
        }

        [BindProperty]
        public TestResult TestResult { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            TestResult.MedicalRecordId = RecordId;
            await _testResultService.CreateTestResult(TestResult);

            return RedirectToPage("./Index");
        }
    }
}
