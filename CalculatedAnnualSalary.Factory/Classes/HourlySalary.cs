using CalculatedAnnualSalary.Factory.Creator;
using CalculatedAnnualSalary.Model.ConsumeAPI.DTO;
using System;

namespace CalculatedAnnualSalary.Factory.Classes
{
    public class HourlySalary : CalculatedSalary
    {
        private const int monthHours= 120;
        private const int monthNumber = 12;
        public override Employee GetAnnualSalary(Employee emp)
        {
            try
            {
                emp.AnnualSalary= monthHours * emp.HourlySalary * monthNumber;
                return emp;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
