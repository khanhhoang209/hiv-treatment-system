using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Implements;

public class OrderRepository : IOrderRepository
{
    
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<decimal> CalculateTotalPriceAsync(Guid medicalRecordId)
    {
        var medicalRecord = await _context.MedicalRecords
            .Include(m => m.Prescription)
                .ThenInclude(p => p.PrescriptionMedicines)
                    .ThenInclude(pm => pm.Medicine)
            .Include(m => m.TestResults)
                .ThenInclude(tr => tr.Type)
            .Include(m => m.TestResults)
                .ThenInclude(tr => tr.ArvRegimen)
                    .ThenInclude(arv => arv.ComboMedicines)
                        .ThenInclude(cm => cm.Medicine)
            .FirstOrDefaultAsync(m => m.Id == medicalRecordId);
        decimal totalPrice = 0;
        if (medicalRecord == null)
            return 0;
        //Giá thuốc trong đơn thuốc
        var prescriptionPrice = medicalRecord.Prescription?.PrescriptionMedicines;
        if (prescriptionPrice != null)
        {
            totalPrice += prescriptionPrice.Sum(pm => pm.BoughtPrice * pm.Quantity);
        }
        
        //Giá của các test result
        var testResults = medicalRecord.TestResults;
        totalPrice += testResults.Sum(tr => tr.Type.Price);
        
        //Giá của các ARV regimen
        foreach (var tr in testResults)
        {
            if (tr.ArvRegimen?.ComboMedicines != null)
            {
                foreach (var combo in tr.ArvRegimen.ComboMedicines)
                {
                    totalPrice += combo.Medicine.Price * combo.Quantity;
                }
            }
        }
    

        return totalPrice;
    }
    public async Task CreateAsync(Order order)
    {
        order.Id = Guid.NewGuid();
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }
    public async Task<Order?> GetOrderByIdAsync(Guid orderId)
    {
        return await _context.Orders
            .Include(o => o.User)
            .Include(o => o.Doctor)
            .Include(o => o.MedicalRecord)
                .ThenInclude(mr => mr.Prescription)
                    .ThenInclude(p => p.PrescriptionMedicines)
                        .ThenInclude(pm => pm.Medicine)
            .Include(o => o.MedicalRecord)
                .ThenInclude(mr => mr.TestResults)
                    .ThenInclude(tr => tr.Type)
            .Include(o => o.MedicalRecord)
                .ThenInclude(mr => mr.TestResults)
                    .ThenInclude(tr => tr.ArvRegimen)
                        .ThenInclude(arv => arv.ComboMedicines)
                            .ThenInclude(cm => cm.Medicine)
            .FirstOrDefaultAsync(o => o.Id == orderId);
    }
    public async Task<List<Order>> GetOrdersByUserIdAsync(Guid userId)
    {
        return await _context.Orders
            .Include(o => o.User)
            .Include(o => o.Doctor)
            .Include(o => o.MedicalRecord)
                .ThenInclude(mr => mr.Prescription)
                    .ThenInclude(p => p.PrescriptionMedicines)
                        .ThenInclude(pm => pm.Medicine)
            .Include(o => o.MedicalRecord)
                .ThenInclude(mr => mr.TestResults)
                    .ThenInclude(tr => tr.Type)
            .Include(o => o.MedicalRecord)
                .ThenInclude(mr => mr.TestResults)
                    .ThenInclude(tr => tr.ArvRegimen)
                        .ThenInclude(arv => arv.ComboMedicines)
                            .ThenInclude(cm => cm.Medicine)
            .Where(o => o.UserId == userId)
            .ToListAsync();
    }
    
    public async Task<List<Order>> GetAllOrdersAsync()
    {
        return await _context.Orders
            .Include(o => o.User)
            .Include(o => o.Doctor)
            .Include(o => o.MedicalRecord)
                .ThenInclude(mr => mr.Prescription)
                    .ThenInclude(p => p.PrescriptionMedicines)
                        .ThenInclude(pm => pm.Medicine)
            .Include(o => o.MedicalRecord)
                .ThenInclude(mr => mr.TestResults)
                    .ThenInclude(tr => tr.Type)
            .Include(o => o.MedicalRecord)
                .ThenInclude(mr => mr.TestResults)
                    .ThenInclude(tr => tr.ArvRegimen)
                        .ThenInclude(arv => arv.ComboMedicines)
                            .ThenInclude(cm => cm.Medicine)
            .ToListAsync();
    }
}