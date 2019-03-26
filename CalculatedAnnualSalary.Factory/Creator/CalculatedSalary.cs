using CalculatedAnnualSalary.Model.ConsumeAPI.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatedAnnualSalary.Factory.Creator
{
    public abstract class CalculatedSalary
    {
        public abstract Employee GetAnnualSalary(Employee emp);
    }
}
