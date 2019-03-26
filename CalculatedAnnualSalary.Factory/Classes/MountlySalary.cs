using CalculatedAnnualSalary.Model.ConsumeAPI.DTO;
using CalculatedAnnualSalary.Factory.Creator;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatedAnnualSalary.Factory.Classes
{
    public class MountlySalary:CalculatedSalary
    {
        private const int monthNumber = 12;
        public override Employee GetAnnualSalary(Employee emp)
        {
            try
            {
                emp.AnnualSalary = emp.HourlySalary * monthNumber;
                return emp;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
