using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dapper;
using Npgsql;

namespace LoveIsDockerPostgreSQL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private const string ConnectionString =
            "Host=localhost;Port=5432;User Id=postgres;Password=postgres;Database=postgres;";

        public CountryController()
        {
            
        }
        
        [HttpGet("get_countries")]
        public async Task<IActionResult> GetCountries()
        {
            await using var dbConnection = new NpgsqlConnection(ConnectionString);
            dbConnection.Open();
            return new OkObjectResult(dbConnection.Query<string>("SELECT distinct name from oof.countries;"));
        }
    }
}