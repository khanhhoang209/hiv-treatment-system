using Application.BackgroundApps;
using Application.SignalR;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Implements;
using Repository.Interfaces;
using Service.Implements;
using Service.Interfaces;
using Service.Mapping;

namespace Application;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddSignalR();
        builder.Services.AddRazorPages();
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        // AutoMapper
        builder.Services.AddAutoMapper(typeof(PrescriptionMappingProfile));

        // Services
        builder.Services.AddScoped<ITestResultService, TestResultService>();
        builder.Services.AddScoped<IMedicalRecordService, MedicalRecordService>();
        builder.Services.AddScoped<IArvService, ArvService>();
        builder.Services.AddScoped<ITypeService, TypeService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IDoctorService, DoctorService>();
        builder.Services.AddScoped<IEmployeeService, EmployeeService>();
        builder.Services.AddScoped<IAppointmentOnlService, AppointmentOnlService>();
        builder.Services.AddScoped<IAppointmentService, AppointmentService>();
        builder.Services.AddScoped<INotificationService, NotificationService>();
        builder.Services.AddScoped<IPaymentService, PaymentService>();
        builder.Services.AddScoped<IClinicService, ClinicService>();
        builder.Services.AddScoped<IDashboardService, DashboardService>();
        builder.Services.AddScoped<ITestTypeService, TestTypeService>();
        builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();
        builder.Services.AddScoped<IPrescriptionMedicineService, PrescriptionMedicineService>();
        builder.Services.AddScoped<IOrderService, OrderService>();
        builder.Services.AddScoped<IStaffService, StaffService>();
        builder.Services.AddScoped<IRoleService, RoleService>();
        builder.Services.AddScoped<IMedicineService, MedicineService>();
        builder.Services.AddScoped<IComboMedicineService, ComboMedicineService>();


        // Repositories
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        builder.Services.AddScoped<IComboMedicineRepository, ComboMedicineRepository>();
        builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout to 30 minutes
            options.Cookie.HttpOnly = true; // Make the session cookie HTTP-only
            options.Cookie.IsEssential = true; // Make the session cookie essential
        });

        builder.Services.AddHostedService<NotificationScheduler>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseSession();

        app.MapHub<NotificationHub>("/hubs/notifications");

        app.MapRazorPages();

        app.MapGet("/", context =>
        {
            context.Response.Redirect("/Login");
            return Task.CompletedTask;
        });
        
        app.Run();
    }
}