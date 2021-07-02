using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Contracts;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IRepositoryManager _repo;
        private readonly ILoggerManager _log;

        public CompaniesController(IRepositoryManager repo, ILoggerManager log)
        {
            _repo = repo;
            _log = log;
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {
            try
            {
                var companies = _repo.Company.GetAllCompanies(trackChanges: false);
                return Ok(companies);
            }
            catch (Exception ex)
            {
                _log.LogError($"something went wrong in the {nameof(GetCompanies)} action  {ex}");
                return StatusCode(500, "Internal Server Error");
               
            }
        }
    }
}
