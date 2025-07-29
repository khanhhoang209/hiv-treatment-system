using Application.Pages.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Service.DTOs;
using Service.Interfaces;

namespace Application.Pages.Prescriptions;

public class CreateModel : AuthorizedPageModel
{
    private readonly IPrescriptionService _prescriptionService;
    private readonly IMedicalRecordService _medicalRecordService;
    private readonly ApplicationDbContext _context;

    public CreateModel(IPrescriptionService prescriptionService, IMedicalRecordService medicalRecordService, ApplicationDbContext context)
    {
        _prescriptionService = prescriptionService;
        _medicalRecordService = medicalRecordService;
        _context = context;
    }

    [BindProperty]
    public CreatePrescriptionDto CreatePrescription { get; set; } = new();

    public SelectList MedicalRecords { get; set; } = null!;
    public SelectList Medicines { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync()
    {
        // Check authentication and authorization
        if (!IsAuthenticated)
        {
            return RedirectToPage("/Login");
        }

        if (!HasPrescriptionAccess)
        {
            return RedirectToPage("/AccessDenied");
        }

        await LoadSelectListsAsync();
        CreatePrescription.PrescriptionDate = DateTime.Now;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        // Debug: Check authentication and authorization
        if (!IsAuthenticated)
        {
            TempData["ErrorMessage"] = "User is not authenticated.";
            return RedirectToPage("/Login");
        }

        if (!HasPrescriptionAccess)
        {
            TempData["ErrorMessage"] = "User does not have prescription access.";
            return RedirectToPage("/AccessDenied");
        }

        // Debug: Log the incoming data
        Console.WriteLine($"Prescription data received:");
        Console.WriteLine($"- MedicalRecordId: {CreatePrescription.MedicalRecordId}");
        Console.WriteLine($"- PrescriptionDate: {CreatePrescription.PrescriptionDate}");
        Console.WriteLine($"- Notes: {CreatePrescription.Notes}");
        Console.WriteLine($"- Medicines count: {CreatePrescription.Medicines?.Count ?? 0}");

        // Debug: Check ModelState
        if (!ModelState.IsValid)
        {
            Console.WriteLine("ModelState is invalid:");
            foreach (var modelError in ModelState)
            {
                Console.WriteLine($"- {modelError.Key}: {string.Join(", ", modelError.Value.Errors.Select(e => e.ErrorMessage))}");
            }
            TempData["ErrorMessage"] = "Please check the form data and try again.";
            await LoadSelectListsAsync();
            return Page();
        }

        try
        {
            var result = await _prescriptionService.CreatePrescriptionAsync(CreatePrescription);
            TempData["SuccessMessage"] = "Prescription created successfully.";
            return RedirectToPage("./Index");
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"An error occurred while creating the prescription: {ex.Message}";
            // Log the exception with details
            Console.WriteLine($"Prescription creation error: {ex.Message}");
            Console.WriteLine($"Stack trace: {ex.StackTrace}");
            if (ex.InnerException != null)
            {
                Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
            }
            await LoadSelectListsAsync();
            return Page();
        }
    }

    private async Task LoadSelectListsAsync()
    {
        try
        {
            // Load Medical Records
            var medicalRecords = await _medicalRecordService.GetAllMedicalRecords();
            MedicalRecords = new SelectList(
                medicalRecords.Select(mr => new
                {
                    Value = mr.Id,
                    Text = $"{mr.User?.Username ?? "Unknown User"} - {mr.Diagnosis} ({mr.RecordDate:dd/MM/yyyy})"
                }),
                "Value",
                "Text"
            );

            // Load Medicines
            var medicines = await _context.Medicines.ToListAsync();
            Medicines = new SelectList(
                medicines.Select(m => new
                {
                    Value = m.Id,
                    Text = $"{m.Name} - ${m.Price:F2}"
                }),
                "Value",
                "Text"
            );
        }
        catch (Exception ex)
        {
            // Log the exception
            MedicalRecords = new SelectList(new List<object>(), "Value", "Text");
            Medicines = new SelectList(new List<object>(), "Value", "Text");
        }
    }
}
