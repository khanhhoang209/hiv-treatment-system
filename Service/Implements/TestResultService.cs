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
    public class TestResultService : ITestResultService
    {
        private readonly IGenericRepository<TestResult> _repo;

        public TestResultService(IGenericRepository<TestResult> testRepo)
        {
            _repo = testRepo;
        }
        public async Task<TestResult> CreateTestResult(TestResult testResult)
        {
            testResult.Id = Guid.NewGuid();
            await _repo.CreateAsync(testResult);
            return testResult;
        }

        public async Task<TestResult> GetTestResultById(Guid testResultId)
        {
            return await _repo.GetByIdAsync(testResultId);
        }

        public async Task<List<TestResult>> GetTestResultsByMedicalRecordId(Guid recordId)
        {
            return await _repo.GetListAsync(a => a.MedicalRecordId == recordId);
        }

    }
}
