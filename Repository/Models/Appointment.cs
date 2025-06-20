﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    [Table("Appointment")]
    public class Appointment
    {
        public Guid Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } = null!;
        public string Notes { get; set; } = null!;
        public Guid DoctorId { get; set; }  
        public Doctor Doctor { get; set; } = null!;
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!; 
    }
}
