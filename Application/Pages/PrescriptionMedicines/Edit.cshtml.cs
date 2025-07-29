using Application.Pages.Shared;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using Service.Interfaces;

namespace Application.Pages.PrescriptionMedicines;

public class EditModel : AuthorizedPageModel
{
    private readonly IPrescriptionMedicineService _prescriptionMedicineService;

    public EditModel(IPrescriptionMedicineService prescriptionMedicineService)
    {
        _prescriptionMedicineService = prescriptionMedicineService;
    }

    [BindProperty]
    public UpdatePrescriptionMedicineDto UpdateMedicine { get; set; } = new();

    public string MedicineName { get; set; } = string.Empty;

    public async Task<IActionResult> OnGetAsync(Guid prescriptionId, Guid medicineId)
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

        var prescriptionMedicine = await _prescriptionMedicineService.GetPrescriptionMedicineAsync(prescriptionId, medicineId);
        if (prescriptionMedicine == null)
        {
            TempData["ErrorMessage"] = "Medicine not found in prescription.";
            return RedirectToPage("./Index", new { prescriptionId });
        }

        UpdateMedicine = new UpdatePrescriptionMedicineDto
        {
            PrescriptionId = prescriptionMedicine.PrescriptionId,
            MedicineId = prescriptionMedicine.MedicineId,
            Quantity = prescriptionMedicine.Quantity,
            Dosage = prescriptionMedicine.Dosage,
            Instructions = prescriptionMedicine.Instructions,
            SumOfMedicationTime = prescriptionMedicine.SumOfMedicationTime,
            BoughtPrice = prescriptionMedicine.BoughtPrice
        };

        MedicineName = prescriptionMedicine.MedicineName;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            // Reload medicine name for display
            var prescriptionMedicine = await _prescriptionMedicineService.GetPrescriptionMedicineAsync(UpdateMedicine.PrescriptionId, UpdateMedicine.MedicineId);
            if (prescriptionMedicine != null)
            {
                MedicineName = prescriptionMedicine.MedicineName;
            }
            return Page();
        }

        try
        {
            var result = await _prescriptionMedicineService.UpdatePrescriptionMedicineAsync(UpdateMedicine);
            TempData["SuccessMessage"] = "Medicine updated successfully.";
            return RedirectToPage("./Index", new { prescriptionId = UpdateMedicine.PrescriptionId });
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = "An error occurred while updating the medicine.";
            // Log the exception
            
            // Reload medicine name for display
            var prescriptionMedicine = await _prescriptionMedicineService.GetPrescriptionMedicineAsync(UpdateMedicine.PrescriptionId, UpdateMedicine.MedicineId);
            if (prescriptionMedicine != null)
            {
                MedicineName = prescriptionMedicine.MedicineName;
            }
            return Page();
        }
    }
}
