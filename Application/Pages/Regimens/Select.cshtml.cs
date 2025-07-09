using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Models;
using Service.DTOs;
using Service.Interfaces;

namespace Application.Pages.Regimens;

public class SelectModel : PageModel
{
    private readonly IArvService _arvService;
    public IList<ArvRegimen> SuggestedRegimens { get; set; } = new List<ArvRegimen>();

    public SelectModel(IArvService arvService)
    {
        _arvService = arvService;
    }

    [BindProperty]
    public PatientCondition PatientCondition { get; set; } = default!;
    public async Task<IActionResult> OnPostAsync()
    {
        SuggestedRegimens = await _arvService.GetSuggestedRegimensAsync(PatientCondition);
        return Page();
    }

}