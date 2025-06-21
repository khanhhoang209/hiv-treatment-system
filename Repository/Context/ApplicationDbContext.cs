using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Type = Repository.Models.Type;

namespace Repository.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Qualification> Qualifications { get; set; }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Staff> Staffs { get; set; }

    public DbSet<Appointment> Appointments { get; set; }

    public DbSet<Clinic> Clinics { get; set; }
    public DbSet<DoctorClinic> DoctorClinics { get; set; }
    public DbSet<StaffClinic> StaffClinics { get; set; }

    public DbSet<MedicalRecord> MedicalRecords { get; set; }

    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicine> PrescriptionMedicines { get; set; }

    public DbSet<TestResult> TestResults { get; set; }

    public DbSet<Type> Types { get; set; }

    public DbSet<ArvRegimen> ArvRegimens { get; set; }
    public DbSet<ComboMedicine> ComboMedicines { get; set; }

    public DbSet<Medicine> Medicines { get; set; }

    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //base.OnModelCreating(modelBuilder);
        //// Additional model configurations can be added here

        modelBuilder.Entity<ApplicationUser>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<Role>()
           .HasKey(r => r.Id);

        modelBuilder.Entity<Order>()
            .HasKey(o => o.Id);

        modelBuilder.Entity<Employee>()
           .HasKey(e => e.Id);

        modelBuilder.Entity<Qualification>()
            .HasKey(q => q.Id);

        modelBuilder.Entity<Doctor>()
           .HasKey(d => d.Id);

        modelBuilder.Entity<Staff>()
            .HasKey(s => s.Id);

        modelBuilder.Entity<Appointment>()
           .HasKey(a => a.Id);

        modelBuilder.Entity<Clinic>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<DoctorClinic>()
           .HasKey(dc => new { dc.DoctorId, dc.ClinicId });

        modelBuilder.Entity<StaffClinic>()
           .HasKey(sc => new { sc.StaffId, sc.ClinicId });

        //Prescription ***
        modelBuilder.Entity<Prescription>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<MedicalRecord>()
           .HasKey(mr => mr.Id);

        modelBuilder.Entity<Type>()
            .HasKey(t => t.Id);

        modelBuilder.Entity<ArvRegimen>()
            .HasKey(ar => ar.Id);

        modelBuilder.Entity<TestResult>()
           .HasKey(tr => tr.Id);

        //Medicine
        modelBuilder.Entity<Medicine>()
            .HasKey(m => m.Id);

        modelBuilder.Entity<ComboMedicine>()
            .HasKey(cm => cm.Id);

        modelBuilder.Entity<PrescriptionMedicine>()
           .HasKey(pm => new { pm.PrescriptionId, pm.MedicineId });

        //Relationships
        //ApplicationUser
        modelBuilder.Entity<ApplicationUser>()
            .HasOne<Role>(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId);

        //Employee
       
        modelBuilder.Entity<Employee>()
            .HasOne<ApplicationUser>(e => e.User)
            .WithMany(u => u.Employees)
            .HasForeignKey(e => e.UserId);


        //Qualification
        
        modelBuilder.Entity<Qualification>()
            .HasOne<Employee>(q => q.Employee)
            .WithMany(e => e.Qualifications)
            .HasForeignKey(q => q.EmployeeId);


        //Doctor
       
        modelBuilder.Entity<Doctor>()
            .HasOne<Employee>(d => d.Employee)
            .WithOne(e => e.Doctor)
            .HasForeignKey<Doctor>(d => d.EmployeeId);


        //Staff
        
        modelBuilder.Entity<Staff>()
            .HasOne<Employee>(s => s.Employee)
            .WithOne(e => e.Staff)
            .HasForeignKey<Staff>(s => s.EmployeeId);

        //Appointment **
       
        modelBuilder.Entity<Appointment>()
            .HasOne<Doctor>(a => a.Doctor)
            .WithMany(a => a.Appointments)
            .HasForeignKey(a => a.DoctorId)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Appointment>()
            .HasOne<ApplicationUser>(a => a.User)
            .WithMany(a => a.Appointments)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Cascade);
       

        //DoctorClinic **
       
        modelBuilder.Entity<DoctorClinic>()
            .HasOne<Doctor>(dc => dc.Doctor)
            .WithMany(d => d.DoctorClinics)
            .HasForeignKey(dc => dc.DoctorId);
        modelBuilder.Entity<DoctorClinic>()
            .HasOne<Clinic>(dc => dc.Clinic)
            .WithMany(d => d.DoctorClinics)
            .HasForeignKey(dc => dc.ClinicId);

        //StaffClinic **
       
        modelBuilder.Entity<StaffClinic>()
            .HasOne<Staff>(sc => sc.Staff)
            .WithMany(s => s.StaffClinics)
            .HasForeignKey(sc => sc.StaffId);
        modelBuilder.Entity<StaffClinic>()
            .HasOne<Clinic>(sc => sc.Clinic)
            .WithMany(s => s.StaffClinics)
            .HasForeignKey(sc => sc.ClinicId);

       

        //MedicalRecord ***
       
        modelBuilder.Entity<MedicalRecord>()
            .HasOne<Doctor>(mr => mr.Doctor)
            .WithMany(m => m.MedicalRecords)
            .HasForeignKey(mr => mr.DoctorId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<MedicalRecord>()
            .HasOne<ApplicationUser>(mr => mr.User)
            .WithMany(m => m.MedicalRecords)
            .HasForeignKey(mr => mr.UserId);
        modelBuilder.Entity<MedicalRecord>()
            .HasOne(mr => mr.Prescription)
            .WithOne(m => m.MedicalRecord)
            .HasForeignKey<Prescription>(p => p.MedicalRecordId)
            .OnDelete(DeleteBehavior.Cascade);
        

        //TestResult **
       
        modelBuilder.Entity<TestResult>()
            .HasOne<MedicalRecord>(tr => tr.MedicalRecord)
            .WithMany(t => t.TestResults)
            .HasForeignKey(tr => tr.MedicalRecordId);
        modelBuilder.Entity<TestResult>()
            .HasOne<Type>(tr => tr.Type)
            .WithMany(t => t.TestResults)
            .HasForeignKey(tr => tr.TypeId);
        modelBuilder.Entity<TestResult>()
            .HasOne<ArvRegimen>(tr => tr.ArvRegimen)
            .WithMany(t => t.TestResults)
            .HasForeignKey(tr => tr.ArvRegimentId);

        
        //PrescriptionMedicine **
       
        modelBuilder.Entity<PrescriptionMedicine>()
            .HasOne<Prescription>(pm => pm.Prescription)
            .WithMany(p => p.PrescriptionMedicines)
            .HasForeignKey(pm => pm.PrescriptionId);
        modelBuilder.Entity<PrescriptionMedicine>()
            .HasOne<Medicine>(pm => pm.Medicine)
            .WithMany(p => p.PrescriptionMedicines)
            .HasForeignKey(pm => pm.MedicineId);

        //ComboMedicine
        
        modelBuilder.Entity<ComboMedicine>()
            .HasOne<ArvRegimen>(cm => cm.ArvRegimen)
            .WithMany(c => c.ComboMedicines)
            .HasForeignKey(cm => cm.ArvRegimenId);
        modelBuilder.Entity<ComboMedicine>()
            .HasOne<Medicine>(cm => cm.Medicine)
            .WithMany(c => c.ComboMedicines)
            .HasForeignKey(cm => cm.MedicineId);

        //Order **
        
        modelBuilder.Entity<Order>()
            .HasOne<ApplicationUser>(o => o.User)
            .WithMany(o => o.Orders)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Order>()
            .HasOne<Doctor>(o => o.Doctor)
            .WithMany(o => o.Orders)
            .HasForeignKey(o => o.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Order>()
            .HasOne<MedicalRecord>(o => o.MedicalRecord)
            .WithMany(o => o.Orders)
            .HasForeignKey(o => o.MedicalRecordId)
            .OnDelete(DeleteBehavior.NoAction);


    }
}