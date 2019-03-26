using CalculatedAnnualSalary.Model.ConsumeAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatedAnnualSalary.Service.Contract
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployeesData();
    }
}
