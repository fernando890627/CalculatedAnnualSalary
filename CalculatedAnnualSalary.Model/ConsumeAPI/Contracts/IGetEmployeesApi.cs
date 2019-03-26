using CalculatedAnnualSalary.Model.ConsumeAPI.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CalculatedAnnualSalary.Model.ConsumeAPI.Contracts
{
    public interface IGetEmployeesApi
    {
        Task<List<Employee>> GetEmployesList();
    }
}
