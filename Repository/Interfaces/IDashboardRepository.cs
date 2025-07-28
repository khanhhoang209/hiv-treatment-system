namespace Repository.Interfaces
{
    public interface IDashboardRepository
    {
        // Thống kê cơ bản
        Task<int> GetTotalPatientsAsync();
        Task<int> GetTotalDoctorsAsync();
        Task<int> GetTotalStaffAsync();
        Task<int> GetTodayAppointmentsAsync();
        Task<int> GetTotalOrdersAsync();
        Task<decimal> GetRevenueThisMonthAsync();
    }
}
