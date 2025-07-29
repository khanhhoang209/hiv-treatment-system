using Application.Pages.Shared;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using Service.Interfaces;

namespace Application.Pages.PrescriptionMedicines;

public class IndexModel : AuthorizedPageModel
{
    private readonly IPrescriptionMedicineService _prescriptionMedicineService;

    public IndexModel(IPrescriptionMedicineService prescriptionMedicineService)
    {
        _prescriptionMedicineService = prescriptionMedicineService;
    }

    public IEnumerable<PrescriptionMedicineDto> PrescriptionMedicines { get; set; } = new List<PrescriptionMedicineDto>();

    public async Task<IActionResult> OnGetAsync(Guid prescriptionId)
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

        try
        {
            PrescriptionMedicines = await _prescriptionMedicineService.GetMedicinesByPrescriptionIdAsync(prescriptionId);
            ViewData["PrescriptionId"] = prescriptionId;
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = "An error occurred while loading prescription medicines.";
            // Log the exception
        }

        return Page();
    }

    public async Task<IActionResult> OnPostDeleteAsync(Guid prescriptionId, Guid medicineId)
    {
        try
        {
            var result = await _prescriptionMedicineService.DeletePrescriptionMedicineAsync(prescriptionId, medicineId);
            if (result)
            {
                TempData["SuccessMessage"] = "Medicine removed from prescription successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Medicine not found or could not be removed.";
            }
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = "An error occurred while removing the medicine.";
            // Log the exception
        }

        return RedirectToPage(new { prescriptionId });
    }
}
