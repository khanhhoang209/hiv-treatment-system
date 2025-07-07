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
using Service.Implements;
using Service.Interfaces;

namespace Application.Pages.TestResults
{
    public class EditModel : PageModel
    {
        private readonly ITestResultService _testResultService;
        private readonly ITypeService _typeService;
        private readonly IArvService _arvService;
        private readonly IMedicalRecordService _medicalRecordService;
        [BindProperty(SupportsGet = true)]
        public Guid RecordId { get; set; }
        public EditModel(ITestResultService testResultService, ITypeService typeService, IArvService arvService, IMedicalRecordService medicalRecordService)
        {
            _testResultService = testResultService;
            _typeService = typeService;
            _arvService = arvService;
            _medicalRecordService = medicalRecordService;
        }

        [BindProperty]
        public TestResult TestResult { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testresult =  await _testResultService.GetTestResultById(id.Value);
            if (testresult == null)
            {
                return NotFound();
            }
            TestResult = testresult;

            var arvList = await _arvService.GetAllAsync();
            var typeList = _typeService.GetAllType();
            ViewData["ArvRegimentId"] = new SelectList(arvList, "Id", "Description");
            ViewData["TypeId"] = new SelectList(typeList, "Id", "Description");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            try
            {
                TestResult.MedicalRecordId = RecordId;
                await _testResultService.UpdateTestResult(TestResult);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!TestResultExists(TestResult.Id))
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

        //private bool TestResultExists(Guid id)
        //{
        //    return _context.TestResults.Any(e => e.Id == id);
        //}
    }
}
