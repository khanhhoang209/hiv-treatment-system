using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implements
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;

        public DashboardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetTotalPatientsAsync()
        {
            // Đếm tất cả User có Role là 'User' (Patient)
            return await _context.Users
                .Where(u => u.Role.Name == "User" && u.Status == "Active")
                .CountAsync();
        }

        public async Task<int> GetTotalDoctorsAsync()
        {
            // Đếm tất cả User có Role là 'Doctor'
            return await _context.Users
                .Where(u => u.Role.Name == "Doctor" && u.Status == "Active")
                .CountAsync();
        }

        public async Task<int> GetTotalStaffAsync()
        {
            // Đếm tất cả User có Role là 'Staff'
            return await _context.Users
                .Where(u => u.Role.Name == "Staff" && u.Status == "Active")
                .CountAsync();
        }

        public async Task<int> GetTodayAppointmentsAsync()
        {
            var today = DateTime.Today;
            return await _context.Appointments
                .Where(a => a.AppointmentDate.Date == today)
                .CountAsync();
        }

        public async Task<int> GetTotalOrdersAsync()
        {
            return await _context.Orders.CountAsync();
        }

        public async Task<decimal> GetRevenueThisMonthAsync()
        {
            var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1);
            
            return await _context.Orders
                .Where(o => o.CreateAt >= startOfMonth && o.CreateAt < endOfMonth)
                .SumAsync(o => o.TotalPrice);
        }
    }
}
