using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Service.Interfaces;

namespace Application.Pages.Regimens
{
    public class EditModel : PageModel
    {
        private readonly IArvService _arvService;
        private readonly IComboMedicineService _comboMedicineService;
        private readonly IMedicineService _medicineService;

        public EditModel(IArvService arvService, IComboMedicineService comboMedicineService, 
            IMedicineService medicineService)
        {
            _arvService = arvService;
            _comboMedicineService = comboMedicineService;
            _medicineService = medicineService;
        }

        [BindProperty]
        public ArvRegimen ArvRegimen { get; set; } = default!;
        [BindProperty]
        public List<Guid> MedicineIds { get; set; } = new();

        [BindProperty]
        public List<int> Quantities { get; set; } = new();

        public List<ComboMedicine> ComboMedicines { get; set; } = new();

        public List<Medicine> AllMedicines { get; set; } = new();


        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arvregimen =  await _arvService.GetByIdAsync((Guid)id);
            if (arvregimen == null!)
            {
                return NotFound();
            }
            ArvRegimen = arvregimen;
            AllMedicines = await _medicineService.GetAllAsync();

            ComboMedicines = await _comboMedicineService.GetComboMedicinesByRegimenIdAsync(ArvRegimen.Id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                AllMedicines = await _medicineService.GetAllAsync();
                ComboMedicines = await _comboMedicineService.GetComboMedicinesByRegimenIdAsync(ArvRegimen.Id);
                return Page();
            }


            await _arvService.UpdateAsync(ArvRegimen);

            var comboMedicines = new List<ComboMedicine>();
            for (int i = 0; i < MedicineIds.Count; i++)
            {
                comboMedicines.Add(new ComboMedicine
                {
                    ArvRegimenId = ArvRegimen.Id,
                    MedicineId = MedicineIds[i],
                    Quantity = Quantities[i]
                });
            }

            await _comboMedicineService.UpdateComboMedicinesAsync(ArvRegimen.Id, comboMedicines);

            return RedirectToPage("./Index");

        }

        private bool ArvRegimenExists(Guid id)
        {
            return _arvService.GetByIdAsync(id) != null!;
        }
    }
}