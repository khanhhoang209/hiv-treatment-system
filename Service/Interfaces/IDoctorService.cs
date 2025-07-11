﻿using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IDoctorService
    {
        List<Doctor> GetAllDoctors();
        Task<Doctor> GetDoctor(Guid id);
    }
}
