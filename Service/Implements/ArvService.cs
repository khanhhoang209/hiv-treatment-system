using Repository.Interfaces;
using Repository.Models;
using Service.DTOs;
using Service.Interfaces;

namespace Service.Implements;

public class ArvService : IArvService
{
    private readonly IUnitOfWork _unitOfWork;

    public ArvService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public async Task<List<ArvRegimen>> GetAllAsync()
    {
        var arvRegimens = await _unitOfWork.ArvRepository.GetAllAsync();
        return arvRegimens;
    }

    public async Task<ArvRegimen> GetByIdAsync(Guid id)
    {
        var arvRegimen = await _unitOfWork.ArvRepository.GetByIdAsync(id);
        return arvRegimen!;
    }

    public async Task<ArvRegimen> CreateAsync(ArvRegimen arvRegimen)
    {
        await _unitOfWork.ArvRepository.CreateAsync(arvRegimen);
        return arvRegimen;
    }

    public async Task<ArvRegimen> UpdateAsync(ArvRegimen arvRegimen)
    {
        await _unitOfWork.ArvRepository.UpdateAsync(arvRegimen);
        return arvRegimen;
    }


    public async Task DeleteAsync(Guid id)
    {
        var arvRegimen = await _unitOfWork.ArvRepository.GetByIdAsync(id);
        if (arvRegimen != null)
        {
            await _unitOfWork.ArvRepository.RemoveAsync(arvRegimen);
        }
    }

    public async Task<List<ArvRegimen>> GetSuggestedRegimensAsync(PatientCondition patientCondition)
    {
        var arvRegimens = new List<ArvRegimen>();
        if (patientCondition.Age < 18)
        {
            var childRegimens = await _unitOfWork.ArvRepository.GetByPatient("trẻ em");
            if (childRegimens != null!)
            {
                arvRegimens.Add(childRegimens);
            }
        }

        if (patientCondition.AcuteHIVInfection)
        {
            var acuteHivRegimens = await _unitOfWork.ArvRepository.GetByPatient("cấp tính");
            if (acuteHivRegimens != null!)
            {
                arvRegimens.Add(acuteHivRegimens);
            }
        }

        if (patientCondition.ChronicHIVInfection)
        {
            var chronicHivRegimens = await _unitOfWork.ArvRepository.GetByPatient("thứ tính");
            if (chronicHivRegimens != null!)
            {
                arvRegimens.Add(chronicHivRegimens);
            }
        }

        if (patientCondition.HasAIDS)
        {
            var aidsRegimens = await _unitOfWork.ArvRepository.GetByPatient("AIDS");
            if (aidsRegimens != null!)
            {
                arvRegimens.Add(aidsRegimens);
            }
        }


        if (patientCondition.IsPregnant)
        {
            var pregnantRegimens = await _unitOfWork.ArvRepository.GetByPatient("mang thai");
            if (pregnantRegimens != null!)
            {
                arvRegimens.Add(pregnantRegimens);
            }
        }

        if (patientCondition.HasHepatitisB)
        {
            var hepatitisBRegimens = await _unitOfWork.ArvRepository.GetByPatient("viêm gan B");
            if (hepatitisBRegimens != null!)
            {
                arvRegimens.Add(hepatitisBRegimens);
            }
        }

        if (patientCondition.HasTB)
        {
            var tbRegimens = await _unitOfWork.ArvRepository.GetByPatient("Lao");
            if (tbRegimens != null!)
            {
                arvRegimens.Add(tbRegimens);
            }
        }

        return arvRegimens;
    }
    public async Task<List<Medicine>> GetAllMedicinesAsync()
    {
        throw new NotImplementedException();
        // return await _unitOfWork..GetAllAsync();
    }

    public async Task UpdateComboMedicinesAsync(Guid arvId, List<ComboMedicine> comboMedicines)
    {
        // var existing = await _unitOfWork.ComboMedicineRepository.GetListAsync(x => x.ArvRegimenId == arvId);
        // foreach (var item in existing)
        // {
        //     await _unitOfWork.ComboMedicineRepository.RemoveAsync(item);
        // }
        //
        // foreach (var combo in comboMedicines)
        // {
        //     await _unitOfWork.ComboMedicineRepository.CreateAsync(combo);
        // }
        //
        // await _unitOfWork.SaveAsync();
    }

}
