using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    public class StatusController : ControllerBase
    {

        [HttpPost("employees")]
        public ActionResult Hire([FromBody]EmployeeCreateRequest employeeToHire)
        {
            return Ok();
        }

        [HttpGet("whoami")]
        public ActionResult WhoAmi([FromHeader(Name ="User-Agent")] string userAgent)
        {
            return Ok($"I see you are running {userAgent}");
        }
    

        // GET /employees
        // GET /employees?department=DEV

        [HttpGet("employees")]
        public ActionResult GetAllEmployees([FromQuery] string department = "All")
        {
            return Ok($"all the employees (filtered on {department})");
        }

        // GET /employees/938938
        [HttpGet("employees/{employeeId:int}")]
        public ActionResult GetAnEmployee(int employeeId)
        {
            // go to the database and get the thing...
            var response = new EmployeeResponse
            {
                Id = employeeId,
                Name = "Bob Smith",
                Department = "DEV",
                HireDate = DateTime.Now.AddDays(-399),
                StartingSalary = 250000
            };
            return Ok(response);
        }

        
        // GET /status -> StatusController#GetStatus
        [HttpGet("/status")]
        public ActionResult GetStatus()
        {
            var status = new StatusResponse
            {
                Message = "Looks good on my end. Party On!",
                CheckedBy = "Joe Schmidt",
                WhenChecked = DateTime.Now
            };

            return Ok(status);
        }
    }

    public class StatusResponse
    {
        public string Message { get; set; }
        public string CheckedBy { get; set; }
        public DateTime WhenChecked { get; set; }
    }

    public class EmployeeCreateRequest
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal StartingSalary { get; set; }
    }

    public class EmployeeResponse { 
        public int Id { get; set; }

        public string Name { get; set; }
        public string Department { get; set; }
        public decimal StartingSalary { get; set; }
        public DateTime HireDate { get; set; }
    }
}
