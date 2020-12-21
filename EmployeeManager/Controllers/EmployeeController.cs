using EmployeeManager.Data;
using EmployeeManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        [HttpGet("{docType}/{docNum}")]
        public ActionResult<Employee> Get(string docType, string docNum)
        {
            return ConnectionBD.GetEmployee(docType, docNum);
        }

        [HttpPost]
        public ActionResult<bool> Post([FromBody] Employee data)
        {
            return ConnectionBD.InsertEmployee(data);
        }

        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Employee data)
        {
            return ConnectionBD.UpdateEmployee(data);
        }
    }
}
