using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITypeService
    {
        List<Repository.Models.Type> GetAllType();

        Repository.Models.Type GetTypeById(Guid id);
    }
}
