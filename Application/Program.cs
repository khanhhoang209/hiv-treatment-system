using Application.BackgroundApps;
using Application.SignalR;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Implements;
using Repository.Interfaces;
using Service.Implements;
using Service.Interfaces;

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

        // Services

        builder.Services.AddScoped<IAppointmentService, AppointmentService>();
        builder.Services.AddScoped<IDoctorService, DoctorService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IArvService, ArvService>();
        builder.Services.AddScoped<INotificationService, NotificationService>();


        // Repositories
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
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

        app.UseStaticFiles();

        app.UseRouting();

        app.UseSession();

        app.UseAuthorization();

        app.MapHub<NotificationHub>("/hubs/notifications");
        
        app.MapRazorPages();

        app.Run();
    }
}