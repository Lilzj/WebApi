using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Contracts;
using WebApi.Entities.DTO;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IRepositoryManager _repo;
        private readonly ILoggerManager _log;
        private readonly IMapper _map;

        public CompaniesController(IRepositoryManager repo, ILoggerManager log, IMapper mapper)
        {
            _repo = repo;
            _log = log;
            _map = mapper;
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {
            try
            {
                var companies = _repo.Company.GetAllCompanies(trackChanges: false);

                var companiesDto = _map.Map<IEnumerable<CompanyDTO>>(companies);

                return Ok(companiesDto);
            }
            catch (Exception ex)
            {
                _log.LogError($"something went wrong in the {nameof(GetCompanies)} action  {ex}");
                return StatusCode(500, "Internal Server Error");
               
            }
        }
    }
}
