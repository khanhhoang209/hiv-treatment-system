using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.DTOs;
using Service.Interfaces;

namespace Application.Pages.Dashboard
{
    public class IndexModel : PageModel
    {
        private readonly IDashboardService _dashboardService;

        public IndexModel(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public DashboardOverviewDto DashboardData { get; set; } = new();

        public async Task OnGetAsync()
        {
            try
            {
                DashboardData = await _dashboardService.GetDashboardOverviewAsync();
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Có lỗi xảy ra khi tải dữ liệu dashboard: " + ex.Message;
            }
        }
    }
}
