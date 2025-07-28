using Repository.Interfaces;
using Service.DTOs;
using Service.Interfaces;

namespace Service.Implements
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardService(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public async Task<DashboardOverviewDto> GetDashboardOverviewAsync()
        {
            // Gọi các methods tuần tự để tránh DbContext threading issues
            var totalPatients = await _dashboardRepository.GetTotalPatientsAsync();
            var totalDoctors = await _dashboardRepository.GetTotalDoctorsAsync();
            var totalStaff = await _dashboardRepository.GetTotalStaffAsync();
            var todayAppointments = await _dashboardRepository.GetTodayAppointmentsAsync();
            var totalOrders = await _dashboardRepository.GetTotalOrdersAsync();
            var revenueThisMonth = await _dashboardRepository.GetRevenueThisMonthAsync();

            return new DashboardOverviewDto
            {
                TotalPatients = totalPatients,
                TotalDoctors = totalDoctors,
                TotalStaff = totalStaff,
                TodayAppointments = todayAppointments,
                TotalOrders = totalOrders,
                RevenueThisMonth = revenueThisMonth
            };
        }
    }
}
