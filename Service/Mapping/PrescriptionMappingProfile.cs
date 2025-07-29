using AutoMapper;
using Repository.Models;
using Service.DTOs;

namespace Service.Mapping;

public class PrescriptionMappingProfile : Profile
{
    public PrescriptionMappingProfile()
    {
        // Prescription mappings
        CreateMap<Prescription, PrescriptionDto>()
            .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.MedicalRecord.User.Username))
            .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.MedicalRecord.Doctor.Employee.FirstName + " " + src.MedicalRecord.Doctor.Employee.LastName))
            .ForMember(dest => dest.Diagnosis, opt => opt.MapFrom(src => src.MedicalRecord.Diagnosis));

        CreateMap<CreatePrescriptionDto, Prescription>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.MedicalRecord, opt => opt.Ignore())
            .ForMember(dest => dest.PrescriptionMedicines, opt => opt.Ignore());

        // PrescriptionMedicine mappings
        CreateMap<PrescriptionMedicine, PrescriptionMedicineDto>()
            .ForMember(dest => dest.MedicineName, opt => opt.MapFrom(src => src.Medicine.Name))
            .ForMember(dest => dest.MedicineDescription, opt => opt.MapFrom(src => src.Medicine.Description))
            .ForMember(dest => dest.MedicinePrice, opt => opt.MapFrom(src => src.Medicine.Price));

        CreateMap<CreatePrescriptionMedicineDto, PrescriptionMedicine>()
            .ForMember(dest => dest.Prescription, opt => opt.Ignore())
            .ForMember(dest => dest.Medicine, opt => opt.Ignore());

        CreateMap<UpdatePrescriptionMedicineDto, PrescriptionMedicine>()
            .ForMember(dest => dest.Prescription, opt => opt.Ignore())
            .ForMember(dest => dest.Medicine, opt => opt.Ignore());
    }
}
