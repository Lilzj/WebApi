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
                var companies = _repo.Company.GetAllCompanies(trackChanges: false);

                var companiesDto = _map.Map<IEnumerable<CompanyDTO>>(companies);

                return Ok(companiesDto);
            
        }

        [HttpGet("{Id}")]
        public IActionResult GetCompany(Guid id)
        {
            var company = _repo.Company.GetCompany(id, trackChanges: false);
            if(company == null)
            {
                _log.LogInfo($"Company with id {id} does not exist in the database");
                return NotFound();
            }
            else
            {
                var companyDto =  _map.Map<CompanyDTO>(company);
                return Ok(companyDto);
            }
        }
    }
}
