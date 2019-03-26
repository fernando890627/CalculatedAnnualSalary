using CalculatedAnnualSalary.Factory.Contracts;
using CalculatedAnnualSalary.Model.ConsumeAPI.Contracts;
using CalculatedAnnualSalary.Model.ConsumeAPI.DTO;
using CalculatedAnnualSalary.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatedAnnualSalary.Service.Classes
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IGetEmployeesApi _employeesApi;
        private readonly IAnnualSalaryCreator _factory;
        public EmployeeService(IGetEmployeesApi empApi, IAnnualSalaryCreator factory)
        {
            this._employeesApi = empApi ?? throw new ArgumentNullException(nameof(empApi));
            this._factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
        public async Task<List<Employee>> GetEmployeesData()
        {
            var result = await _employeesApi.GetEmployesList();
            if (result is null || !result.Any())
            {
                return new List<Employee>();
            }
            return result.Select(e => _factory.GenerateEmployeeWithAnnualSalary(e)).ToList();
        }
    }
}
