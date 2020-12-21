using EmployeeManager.Data;
using EmployeeManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Authentication> Get()
        {
            return ConnectionBD.GetAuthenticationData(1);
        }
    }
}
