using Application.Pages.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.DTOs;
using Service.Interfaces;

namespace Application.Pages.Prescriptions;

public class IndexModel : AuthorizedPageModel
{
    private readonly IPrescriptionService _prescriptionService;

    public IndexModel(IPrescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }

    public IEnumerable<PrescriptionDto> Prescriptions { get; set; } = new List<PrescriptionDto>();

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

        try
        {
            Prescriptions = await _prescriptionService.GetAllPrescriptionsAsync();
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = "An error occurred while loading prescriptions.";
            // Log the exception
        }

        return Page();
    }

    public async Task<IActionResult> OnPostDeleteAsync(Guid id)
    {
        try
        {
            var result = await _prescriptionService.DeletePrescriptionAsync(id);
            if (result)
            {
                TempData["SuccessMessage"] = "Prescription deleted successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Prescription not found or could not be deleted.";
            }
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = "An error occurred while deleting the prescription.";
            // Log the exception
        }

        return RedirectToPage();
    }
}
