using Service.DTOs;

namespace Service.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardOverviewDto> GetDashboardOverviewAsync();
    }
}
