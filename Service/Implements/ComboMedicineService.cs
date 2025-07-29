using Repository.Interfaces;
using Repository.Models;
using Service.Interfaces;

namespace Service.Implements;

public class ComboMedicineService : IComboMedicineService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public ComboMedicineService( IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    

    public async Task UpdateComboMedicinesAsync(Guid arvId, List<ComboMedicine> comboMedicines)
    {
        var existing = await _unitOfWork.ComboMedicineRepository.GetListAsync(x => x.ArvRegimenId == arvId);
        foreach (var item in existing)
        {
            await _unitOfWork.ComboMedicineRepository.RemoveAsync(item);
        }

        foreach (var combo in comboMedicines)
        {
            await _unitOfWork.ComboMedicineRepository.CreateAsync(combo);
        }

        await _unitOfWork.SaveChangesAsync();
    }
    public async Task<List<ComboMedicine>> GetComboMedicinesByRegimenIdAsync(Guid arvId)
    {
        return await _unitOfWork.ComboMedicineRepository.GetListWithConditionAsync(
            cm => cm.ArvRegimenId == arvId,
            cm => cm.Medicine
        );
    }
}