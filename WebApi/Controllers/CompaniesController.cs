using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Contracts;
using WebApi.Entities.DTO;
using WebApi.Entities.Models;
using WebApi.ModelBinding;

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
        public async Task<IActionResult> GetAllCompaniesAsync()
        {
                var companies = await _repo.Company.GetAllCompaniesAsync(trackChanges: false);

                var companiesDto = _map.Map<IEnumerable<CompanyDTO>>(companies);

                return Ok(companiesDto);
            
        }

        [HttpGet("{id}", Name ="GetCompany")]
        public async Task<IActionResult> GetCompanyAsync(string id)
        {
            var company = await _repo.Company.GetCompanyAsync(id, trackChanges: false);
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
        public async Task<ActionResult> AddCompany([FromBody] AddCompanyDTO company)
        {
            if(company == null)
            {
                _log.LogInfo("companyDTO object sent from client id null.");
                return BadRequest("companyDTO object is null");
            }

            var companyEntity = _map.Map<Company>(company);
             _repo.Company.AddCompany(companyEntity);
            await _repo.SaveAsync();

            var companyReturn = _map.Map<CompanyDTO>(companyEntity);
            return CreatedAtRoute("GetCompany", new { id = companyReturn.Id }, companyReturn);
        }

        [HttpGet("collection/({ids})", Name ="companies")]
        public async Task<IActionResult> GetCompaniesAsync([ModelBinder(BinderType =typeof(ArrayModelBinder))]IEnumerable<string> ids)
        {
            if(ids == null)
            {
                _log.LogError("Ids sent is null");
                return BadRequest("Ids sent is null");
            }

            var companyEntities = await _repo.Company.GetByIdsAsync(ids, trackChanges: false);
            if(ids.Count() != companyEntities.Count())
            {
                _log.LogError("Some input ids are not valid");
                return NotFound();
            }

            var companiesReturn = _map.Map<IEnumerable<CompanyDTO>>(companyEntities);
            return Ok(companiesReturn);
        }

        [HttpPost("collection")] 
        public async Task<IActionResult> AddCompaniesAsync([FromBody] IEnumerable<AddCompanyDTO> companies)
        {
            if (companies == null)
            { 
                _log.LogError("Company collection sent from client is null."); 
                return BadRequest("Company collection is null"); 
            } 

            var companyEntities = _map.Map<IEnumerable<Company>>(companies);

            foreach (var company in companyEntities)
            {
                _repo.Company.AddCompany(company); 
            } 
            await _repo.SaveAsync();

            var companiesReturn = _map.Map<IEnumerable<CompanyDTO>>(companyEntities); 

            var ids = string.Join(",", companiesReturn.Select(c => c.Id));
            return CreatedAtRoute("companies", new { ids }, companiesReturn);
        }

        [HttpDelete("{id}")] 
        public async Task<IActionResult> DeleteCompanyAsync(string id)
        {
            var company = await _repo.Company.GetCompanyAsync(id, trackChanges: false);

            if (company == null) 
            {
                _log.LogInfo($"Company with id: {id} doesn't exist in the database.");
                return NotFound(); 
            }

            _repo.Company.DeleteCompany(company);
            await _repo.SaveAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompanyAsync(string id, [FromBody] UpdateCompanyDTO company)
        {
            if(company == null)
            {
                _log.LogError("UpdateCompanyDTO sent from client is null");
                return BadRequest("UpdateCompanyDTO is null");
            }

            var companyEntity = await _repo.Company.GetCompanyAsync(id, trackChanges: false);
            if(companyEntity == null)
            {
                _log.LogInfo($"Company with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _map.Map(company, companyEntity);
            await _repo.SaveAsync();

            return NoContent();
        }
    }
}
