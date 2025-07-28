using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITestResultService
    {
        Task<TestResult> CreateTestResult(TestResult testResult);
        Task<bool> UpdateTestResult(TestResult testResult);
        Task<List<TestResult>> GetTestResults();
        Task<List<TestResult>> GetTestResultsByMedicalRecordId(Guid recordId);
        Task<TestResult> GetTestResultById(Guid testResultId);
        Task<bool> CreateTestResults(List<TestResult> testResults);
    }
}