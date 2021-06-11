using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dapper;
using LoveIsDockerPostgreSQL.Models;
using Npgsql;

namespace LoveIsDockerPostgreSQL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private const string ConnectionString =
            "Host=localhost;Port=5432;User Id=postgres;Password=postgres;Database=postgres;";
        
        /// <summary>
        /// Returns the list of countries in the database
        /// </summary>
        /// <returns>List of countries' names</returns>
        [HttpGet("get_countries")]
        public async Task<IActionResult> GetCountries()
        {
            await using var dbConnection = new NpgsqlConnection(ConnectionString);
            dbConnection.Open();
            return new OkObjectResult(dbConnection.Query<string>("SELECT distinct name from oof.countries;"));
        }
        
        /// <summary>
        /// Returns info about the specific country by its name
        /// </summary>
        /// <param name="countryName">A name of the country</param>
        /// <returns></returns>
        [HttpGet("get_country_info_by_name")]
        public async Task<IActionResult> GetCountryInfoByName([Required] string countryName)
        {
            await using var dbConnection = new NpgsqlConnection(ConnectionString);
            dbConnection.Open();
            return new OkObjectResult(dbConnection.Query<CountryInfo>("SELECT *  from oof.countries where name = @countryName;", new {countryName}));
        }
    }
}