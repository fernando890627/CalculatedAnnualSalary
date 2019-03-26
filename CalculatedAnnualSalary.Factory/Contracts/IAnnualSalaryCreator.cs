using CalculatedAnnualSalary.Model.ConsumeAPI.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatedAnnualSalary.Factory.Contracts
{
    public interface IAnnualSalaryCreator
    {
        Employee GenerateEmployeeWithAnnualSalary(Employee emp);
    }
}
