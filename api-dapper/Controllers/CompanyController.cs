using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace api_dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private string _connection = @"Server=db4free.net; Database=orm_upc; Uid=estudiante_upc; Password=1estudiante6software;";
        [HttpGet]
        public IActionResult GetCompanies()
        {
            IEnumerable<Models.Company> companies = null;
            using (var db = new MySqlConnection(_connection))
            {
                var query = "SELECT Id, Name, Address, Country FROM company";
                companies = db.Query<Models.Company>(query);
            }
            return Ok(companies);
        }
    }
}
