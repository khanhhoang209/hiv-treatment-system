using Repository.Interfaces;
using Repository.Models;
using Service.Interfaces;

namespace Service.Implements;

public class DoctorService : IDoctorService
{
    private readonly IGenericRepository<Doctor> _repo;
    public DoctorService(IGenericRepository<Doctor> doctorRepo)
    {
        _repo = doctorRepo;
    }
    public List<Doctor> GetAllDoctors()
    {

        return _repo.GetAll();
    }
    public Doctor? GetDoctorById(Guid id)
    {
        return _repo.GetById(id);
    }
}