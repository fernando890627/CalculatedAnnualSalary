using CalculatedAnnualSalary.Factory.Classes;
using CalculatedAnnualSalary.Factory.Contracts;
using CalculatedAnnualSalary.Factory.Enums;
using CalculatedAnnualSalary.Model.ConsumeAPI.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatedAnnualSalary.Factory.Creator
{
    public class AnnualSalaryCreator: IAnnualSalaryCreator
    {
        public Employee GenerateEmployeeWithAnnualSalary(Employee emp)
        {
            CalculatedSalary factory =null;
            switch (GetType(emp.ContractTypeName))
            {
                case ContractType.HourlyContract:
                    factory = new HourlySalary();
                    break;
                case ContractType.MonthlyContract:
                    factory = new MountlySalary();
                    break;
                default:
                    break;
            }
            Employee resultEmployee = factory.GetAnnualSalary(emp);
            return resultEmployee;
        }

        ContractType GetType(string type)
        {
            Enum.TryParse(type, out ContractType contractTypeEnum);
            return contractTypeEnum;
        }
    }
}
