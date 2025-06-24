using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IArvService
    {
        Task<List<ArvRegimen>> GetAllAsync();
        Task<ArvRegimen> GetAsync(Guid id);
    }
}
