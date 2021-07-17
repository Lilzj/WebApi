using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Contracts;
using WebApi.Entities.DTO;
using WebApi.Entities.Models;

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

        [HttpGet("{id}", Name ="GetCompany")]
        public IActionResult GetCompany(string id)
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

        [HttpPost]
        public IActionResult AddCompany([FromBody] AddCompanyDTO company)
        {
            if(company == null)
            {
                _log.LogInfo("companyDTO object sent from client id null.");
                return BadRequest("companyDTO object is null");
            }

            var companyEntity = _map.Map<Company>(company);
            _repo.Company.AddCompany(companyEntity);
            _repo.Save();

            var companyReturn = _map.Map<CompanyDTO>(companyEntity);
            return CreatedAtRoute("GetCompany", new { id = companyReturn.Id }, companyReturn);
        }
    }
}
