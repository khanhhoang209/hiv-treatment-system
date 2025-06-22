using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Models;
using Service.Interfaces;

namespace Application.Pages.Regimens
{
    public class IndexModel : PageModel
    {
        private readonly IArvService _arvService;

        public IndexModel(IArvService arvService)
        {
            _arvService = arvService;
        }


        public IList<ArvRegimen> ArvRegimen { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ArvRegimen = await _arvService.GetAllAsync();
        }
    }
}