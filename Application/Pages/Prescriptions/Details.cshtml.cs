using Application.Pages.Shared;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using Service.Interfaces;

namespace Application.Pages.Prescriptions;

public class DetailsModel : AuthorizedPageModel
{
    private readonly IPrescriptionService _prescriptionService;

    public DetailsModel(IPrescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }

    public PrescriptionDto Prescription { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        // Check authentication and authorization
        if (!IsAuthenticated)
        {
            return RedirectToPage("/Login");
        }
        
        try
        {
            Prescription = await _prescriptionService.GetPrescriptionByIdAsync(id);
            if (Prescription == null)
            {
                TempData["ErrorMessage"] = "Prescription not found.";
                return RedirectToPage("./Index");
            }
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = "An error occurred while loading the prescription.";
            // Log the exception
            return RedirectToPage("./Index");
        }

        return Page();
    }
}
