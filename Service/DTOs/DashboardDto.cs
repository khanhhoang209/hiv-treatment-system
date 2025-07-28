namespace Service.DTOs
{
    public class DashboardOverviewDto
    {
        // Thống kê cơ bản
        public int TotalPatients { get; set; }
        public int TotalDoctors { get; set; }
        public int TotalStaff { get; set; }
        public int TodayAppointments { get; set; }
        public int TotalOrders { get; set; }
        public decimal RevenueThisMonth { get; set; }
    }

    public class MonthlyDataDto
    {
        public int Month { get; set; }
        public string MonthName { get; set; } = null!;
        public int Count { get; set; }
        public decimal Revenue { get; set; }
    }

    public class WeeklyDataDto
    {
        public int WeekNumber { get; set; }
        public string WeekLabel { get; set; } = null!;
        public int Count { get; set; }
    }
}
