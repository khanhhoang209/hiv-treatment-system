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
    public class DetailsModel : PageModel
    {
        private readonly ITestResultService _testResultService;
        private readonly ITypeService _typeService;
        private readonly IArvService _arvService;

        public DetailsModel(ITestResultService testResultService, ITypeService typeService, IArvService arvService)
        {
            _testResultService = testResultService;
            _typeService = typeService;
            _arvService = arvService;
        }

        public TestResult TestResult { get; set; } = default!;
        public Repository.Models.Type Type { get; set; }
        public ArvRegimen Regimen { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testresult = await _testResultService.GetTestResultById(id.Value);
            var type = _typeService.GetTypeById(testresult.TypeId);
            var arv = await _arvService.GetAsync(testresult.ArvRegimentId);
            if (testresult == null)
            {
                return NotFound();
            }
            else
            {
                TestResult = testresult;
                Type = type;
                Regimen = arv;
            }
            return Page();
        }
    }
}
