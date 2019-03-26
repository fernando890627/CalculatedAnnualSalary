using CalculatedAnnualSalary.Factory.Contracts;
using CalculatedAnnualSalary.Model.ConsumeAPI.Contracts;
using CalculatedAnnualSalary.Model.ConsumeAPI.DTO;
using CalculatedAnnualSalary.Service.Classes;
using CalculatedAnnualSalary.Service.Contract;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CalculatedAnnualSalary.Test
{
    public class FactoryTest
    {
        private readonly Mock<IAnnualSalaryCreator> _creator;
        private readonly Mock<IGetEmployeesApi> _getEmployeesApi;
        private IEmployeeService _api => new EmployeeService(_getEmployeesApi.Object, _creator.Object);
        private new List<Employee> model = new List<Employee>()
            {
                new Employee()
                {
                    Id=3,
                    Name="Fernando",
                    ContractTypeName="MonthlySalaryEmployee",
                    RoleId=1,
                    HourlySalary=200,
                    MonthlySalary=200
                }
            };

        public FactoryTest()
        {
            _creator = new Mock<IAnnualSalaryCreator>();
            _getEmployeesApi = new Mock<IGetEmployeesApi>();
        }

        private void SetupGet()
        {
            _getEmployeesApi.Setup(a => a.GetEmployesList()).ReturnsAsync(() => new List<Employee>()
            {
                new Employee()
                {
                    Id=3,
                    Name="Fernando",
                    ContractTypeName="HourlySalaryEmployee",
                    RoleId=1,
                    HourlySalary=200,
                    MonthlySalary=200
                }
            });
        }

        [Fact]        
        public void Get_Employee_Object()
        {
            SetupGet();
            var obj = _api.GetEmployeesData();
            Assert.Equal(model,model);
        }
    }
}
