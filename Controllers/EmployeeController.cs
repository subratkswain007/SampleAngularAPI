using Microsoft.AspNetCore.Mvc;
using SampleAngularAPI.Data;
using SampleAngularAPI.Model;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleAngularAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly EmployeeDataContext employeeDataContext;

        public EmployeeController(EmployeeDataContext _employeeDataContext)
        {
            this.employeeDataContext = _employeeDataContext;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var getEmployees = employeeDataContext.GetEmployees();
            if (getEmployees is null)
                return Ok(ApiResponse.CreateSuccessResponse(getEmployees, "No data found"));
            else
                return Ok(ApiResponse.CreateSuccessResponse(getEmployees));
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            if (employee != null)
            {
                employee.CreatedDateTimeUtc = DateTime.Now;
            }
            var addEmployee = employeeDataContext.AddEmployee(employee);
            if (addEmployee)
                return Ok(ApiResponse.CreateSuccessResponse(addEmployee, "Added successfully"));
            else
                return Ok(ApiResponse.CreateSuccessResponse(addEmployee));
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
