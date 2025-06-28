using Repository.Interfaces;
using Repository.Models;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implements
{
    public class AppointmentOnlService : IAppointmentOnlService
    {
        private readonly IAppointmentRepository _repository;

        public AppointmentOnlService(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAppointmentAsync(Appointment appointment)
        {
            appointment.Id = Guid.NewGuid();
            appointment.Status = "Pending";
            await _repository.CreateAsync(appointment);
        }

        public async Task<List<Appointment>> GetAppointmentsByUserIdAsync(Guid userId)
        {
            return await _repository.GetAllByUserIdAsync(userId);
        }
    }
}
