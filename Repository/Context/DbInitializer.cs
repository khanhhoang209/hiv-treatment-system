using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Context
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            // Ensure database is created
            await context.Database.EnsureCreatedAsync();

            // Seed test user if not exists
            if (!await context.Users.AnyAsync(u => u.Email == "test@example.com"))
            {
                var testUser = new ApplicationUser
                {
                    Id = Guid.NewGuid(),
                    UserName = "test@example.com",
                    Email = "test@example.com",
                    EmailConfirmed = true,
                    FullName = "Test User",
                    PhoneNumber = "0123456789",
                    Address = "Test Address"
                };

                await context.Users.AddAsync(testUser);
                await context.SaveChangesAsync();
            }

            // Seed sample doctors if not exists
            if (!await context.Doctors.AnyAsync())
            {
                var doctors = new List<Doctor>
                {
                    new Doctor
                    {
                        Id = Guid.NewGuid(),
                        FullName = "BS. Nguyễn Văn A",
                        Specialization = "Khoa HIV/AIDS",
                        PhoneNumber = "0987654321",
                        Email = "doctor1@example.com"
                    },
                    new Doctor
                    {
                        Id = Guid.NewGuid(),
                        FullName = "BS. Trần Thị B",
                        Specialization = "Khoa Nội tổng hợp",
                        PhoneNumber = "0987654322",
                        Email = "doctor2@example.com"
                    }
                };

                await context.Doctors.AddRangeAsync(doctors);
                await context.SaveChangesAsync();
            }
        }
    }
}
