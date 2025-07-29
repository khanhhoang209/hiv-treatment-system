using Application.Pages.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Service.DTOs;
using Service.Interfaces;

namespace Application.Pages.PrescriptionMedicines;

public class CreateModel : AuthorizedPageModel
{
    private readonly IPrescriptionMedicineService _prescriptionMedicineService;
    private readonly ApplicationDbContext _context;

    public CreateModel(IPrescriptionMedicineService prescriptionMedicineService, ApplicationDbContext context)
    {
        _prescriptionMedicineService = prescriptionMedicineService;
        _context = context;
    }

    [BindProperty]
    public CreatePrescriptionMedicineDto CreateMedicine { get; set; } = new();

    [BindProperty]
    public Guid PrescriptionId { get; set; }

    public SelectList Medicines { get; set; } = null!;

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

        PrescriptionId = prescriptionId;
        await LoadSelectListsAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await LoadSelectListsAsync();
            return Page();
        }

        try
        {
            var result = await _prescriptionMedicineService.CreatePrescriptionMedicineAsync(PrescriptionId, CreateMedicine);
            TempData["SuccessMessage"] = "Medicine added to prescription successfully.";
            return RedirectToPage("./Index", new { prescriptionId = PrescriptionId });
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = "An error occurred while adding the medicine to prescription.";
            // Log the exception
            await LoadSelectListsAsync();
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
                    Text = $"{m.Name} - ${m.Price:F2}",
                    DataPrice = m.Price
                }),
                "Value",
                "Text"
            );

            // Add data-price attribute for auto-fill functionality
            foreach (var item in Medicines)
            {
                var medicine = medicines.First(m => m.Id.ToString() == item.Value);
                item.Selected = false;
                // Note: SelectListItem doesn't support custom attributes directly
                // We'll handle this in the Razor page
            }
        }
        catch (Exception ex)
        {
            // Log the exception
            Medicines = new SelectList(new List<object>(), "Value", "Text");
        }
    }
}
