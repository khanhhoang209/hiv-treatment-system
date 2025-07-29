using Repository.Models;

namespace Service.Interfaces;

public interface IComboMedicineService
{
    Task UpdateComboMedicinesAsync(Guid arvId, List<ComboMedicine> comboMedicines);
    Task<List<ComboMedicine>> GetComboMedicinesByRegimenIdAsync(Guid arvId);
}