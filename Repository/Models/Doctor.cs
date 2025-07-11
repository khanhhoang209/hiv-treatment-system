﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    [Table("Doctor")]
    public class Doctor
    {
        public Guid Id { get; set; }
        public string Specialization { get; set; } = null!;
        public string LicenseNumber { get; set; } = null!;
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
        public ICollection<Appointment> Appointments { get; set; } = null!;
        public ICollection<DoctorClinic> DoctorClinics { get; set; } = null!;
        public ICollection<MedicalRecord> MedicalRecords { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = null!;
    }
}
