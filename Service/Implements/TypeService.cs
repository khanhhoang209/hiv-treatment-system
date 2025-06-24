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
    public class TypeService : ITypeService
    {
        private readonly IGenericRepository<Repository.Models.Type> _repo;
        public TypeService(IGenericRepository<Repository.Models.Type> doctorRepo)
        {
            _repo = doctorRepo;
        }

        public List<Repository.Models.Type> GetAllType()
        {
            return _repo.GetAll();
        }

        public Repository.Models.Type GetTypeById(Guid id)
        {
            return _repo.GetById(id);
        }
    }
}
