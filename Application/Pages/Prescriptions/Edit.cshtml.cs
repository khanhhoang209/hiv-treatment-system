using Application.Pages.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Service.DTOs;
using Service.Interfaces;

namespace Application.Pages.Prescriptions;

public class EditModel : AuthorizedPageModel
{
    private readonly IPrescriptionService _prescriptionService;
    private readonly ApplicationDbContext _context;

    public EditModel(IPrescriptionService prescriptionService, ApplicationDbContext context)
    {
        _prescriptionService = prescriptionService;
        _context = context;
    }

    [BindProperty]
    public UpdatePrescriptionDto UpdatePrescription { get; set; } = new();

    public SelectList Medicines { get; set; } = null!;
    public string MedicalRecordInfo { get; set; } = string.Empty;

    public async Task<IActionResult> OnGetAsync(Guid id)
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

        var prescription = await _prescriptionService.GetPrescriptionByIdAsync(id);
        if (prescription == null)
        {
            TempData["ErrorMessage"] = "Prescription not found.";
            return RedirectToPage("./Index");
        }

        UpdatePrescription = new UpdatePrescriptionDto
        {
            Id = prescription.Id,
            PrescriptionDate = prescription.PrescriptionDate,
            Notes = prescription.Notes,
            Medicines = prescription.PrescriptionMedicines.Select(pm => new CreatePrescriptionMedicineDto
            {
                MedicineId = pm.MedicineId,
                Quantity = pm.Quantity,
                Dosage = pm.Dosage,
                Instructions = pm.Instructions,
                SumOfMedicationTime = pm.SumOfMedicationTime,
                BoughtPrice = pm.BoughtPrice
            }).ToList()
        };

        MedicalRecordInfo = $"{prescription.PatientName} - {prescription.Diagnosis} ({prescription.PrescriptionDate:dd/MM/yyyy})";

        await LoadSelectListsAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await LoadSelectListsAsync();
            await LoadMedicalRecordInfo();
            return Page();
        }

        try
        {
            var result = await _prescriptionService.UpdatePrescriptionAsync(UpdatePrescription);
            TempData["SuccessMessage"] = "Prescription updated successfully.";
            return RedirectToPage("./Index");
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = "An error occurred while updating the prescription.";
            // Log the exception
            await LoadSelectListsAsync();
            await LoadMedicalRecordInfo();
            return Page();
        }
    }

    private async Task LoadSelectListsAsync()
    {
        try
        {
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
            Medicines = new SelectList(new List<object>(), "Value", "Text");
        }
    }

    private async Task LoadMedicalRecordInfo()
    {
        try
        {
            var prescription = await _prescriptionService.GetPrescriptionByIdAsync(UpdatePrescription.Id);
            if (prescription != null)
            {
                MedicalRecordInfo = $"{prescription.PatientName} - {prescription.Diagnosis} ({prescription.PrescriptionDate:dd/MM/yyyy})";
            }
        }
        catch (Exception ex)
        {
            // Log the exception
            MedicalRecordInfo = "Unable to load medical record information";
        }
    }
}
