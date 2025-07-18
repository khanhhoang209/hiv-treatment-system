﻿using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IAppointmentRepository
    {
        Task CreateAsync(Appointment appointment);
        Task<List<Appointment>> GetAllByUserIdAsync(Guid userId);
    }
}
