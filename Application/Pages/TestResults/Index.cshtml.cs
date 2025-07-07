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

namespace Application.Pages.TestResults
{
    public class IndexModel : PageModel
    {
        private readonly ITestResultService _testResultService;

        public IndexModel(ITestResultService testResultService)
        {
            _testResultService = testResultService;
        }

        [BindProperty(SupportsGet = true)]
        public Guid RecordId { get; set; }

        public IList<TestResult> TestResult { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            if (RecordId == Guid.Empty)
            {
                TestResult = await _testResultService.GetTestResults();
            } 
            else
            {
                TestResult = await _testResultService.GetTestResultsByMedicalRecordId(RecordId);
            }
    
            return Page();
        }
    }
}
