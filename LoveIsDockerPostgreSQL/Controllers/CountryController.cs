using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LoveIsDockerPostgreSQL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        /// <summary>
        /// Returns a user object with specific email.
        /// </summary>
        /// <param name="email">Email that belongs to user.</param>
        /// <returns>The object of user.</returns>
        [HttpGet("get_user_by_email")]
        public IActionResult GetUserByEmail([FromQuery] string email)
        {

            return new OkObjectResult(new {Ok="ok"});
        }
    }
}