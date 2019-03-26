using CalculatedAnnualSalary.Model.ConsumeAPI.DTO;
using CalculatedAnnualSalary.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CalculatedAnnualSalary.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {

            _employeeService = employeeService;
        }
        // GET api/values
        [HttpGet]
        public async Task<List<Employee>> Get()
        {
            var employeesData = await _employeeService.GetEmployeesData();
            return employeesData;
        }
    }
}
