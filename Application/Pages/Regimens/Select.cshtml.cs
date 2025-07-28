using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Models;
using Service.DTOs;
using Service.Interfaces;

namespace Application.Pages.Regimens;

public class SelectModel : PageModel
{
    private readonly IArvService _arvService;
    private readonly ITestResultService _testResultService;
    private readonly IMedicalRecordService _medicalRecordService;
    private readonly ITestTypeService _testTypeService;

    public IList<ArvRegimen> SuggestedRegimens { get; set; } = new List<ArvRegimen>();
    public IList<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
    public IList<Repository.Models.Type> TestTypes { get; set; } = new List<Repository.Models.Type>();

    public SelectModel(IArvService arvService, ITestResultService testResultService, IMedicalRecordService medicalRecordService, ITestTypeService testTypeService)
    {
        _arvService = arvService;
        _testResultService = testResultService;
        _medicalRecordService = medicalRecordService;
        _testTypeService = testTypeService;
    }

    [BindProperty]
    public PatientCondition PatientCondition { get; set; } = default!;
    public async Task<IActionResult> OnPostAsync()
    {
        SuggestedRegimens = await _arvService.GetSuggestedRegimensAsync(PatientCondition);
        MedicalRecords = await _medicalRecordService.GetAllMedicalRecords(); // hoặc lấy theo UserId
        TestTypes = await _testTypeService.GetAllAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostSaveTestResultsAsync(
        [FromForm] List<Guid> SelectedRegimenIds,
        [FromForm] string Result,
        [FromForm] string Notes,
        [FromForm] Guid MedicalRecordId,
        [FromForm] Guid TypeId)
    {
        var testResults = SelectedRegimenIds.Select(id => new TestResult
        {
            Id = Guid.NewGuid(),
            TestDate = DateTime.Now,
            Result = Result,
            Notes = Notes,
            MedicalRecordId = MedicalRecordId,
            ArvRegimentId = id,
            TypeId = TypeId
        }).ToList();

        await _testResultService.CreateTestResults(testResults); // Implement method in service

        TempData["SuccessMessage"] = "Đã lưu kết quả test thành công.";
        return RedirectToPage(); // Hoặc return Page() nếu muốn hiển thị tiếp dữ liệu
    }


}