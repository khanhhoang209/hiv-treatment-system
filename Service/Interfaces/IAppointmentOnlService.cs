using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAppointmentOnlService
    {
        Task CreateAppointmentAsync(Appointment appointment);
        Task<List<Appointment>> GetAppointmentsByUserIdAsync(Guid userId);
    }
}
