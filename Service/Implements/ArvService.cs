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
    public class ArvService : IArvService
    {
        private readonly IGenericRepository<ArvRegimen> _repo;

        public ArvService(IGenericRepository<ArvRegimen> arvRepo)
        {
            _repo = arvRepo;
        }


        public async Task<List<ArvRegimen>> GetAllAsync()
        {
            var arvRegimens = await _repo.GetAllAsync();
            return arvRegimens;
        }

        public async Task<ArvRegimen> GetAsync(Guid id)
        {
            return await _repo.GetByIdAsync(id);
        }
    }
}
