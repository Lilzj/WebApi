using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Contracts;
using WebApi.Entities.DTO;
using WebApi.Entities.Models;
using static WebApi.Entities.Pagination.RequestParam;

namespace WebApi.Controllers
{
    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IRepositoryManager _repo;
        private readonly ILoggerManager _log;
        private readonly IMapper _map;
        
        public EmployeesController(IRepositoryManager repository, ILoggerManager logger, 
            IMapper mapper) 
        {
            _repo = repository;
            _log = logger;
            _map = mapper; 
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeesForCompanyAsync(string companyId, [FromQuery] EmployeeParam employeeParam)
        {

            if(!employeeParam.ValidAgeRange)
                return BadRequest("Max age can't be less than min age.");

            var company = await _repo.Company.GetCompanyAsync(companyId, trackChanges: false);
            if (company == null)
            {
                _log.LogInfo($"Company with the Id {companyId} does not exist in the database");
                return NotFound();
            }
            else
            {
                var employeesFromDb = await _repo.Employee.GetEmployeesAsync(companyId, employeeParam, trackChanges: false);

                Response.Headers.Add("pagination", JsonConvert.SerializeObject(employeesFromDb.metaData));

                var employessDto = _map.Map<IEnumerable<EmployeeDTO>>(employeesFromDb);

                return Ok(employessDto);              
            }
        }

        [HttpGet("{id}", Name = "companyId")]
        public async Task<IActionResult> GetEmployeeForACompanyAsync(string companyId, string id)
        {
            var comapny = await _repo.Company.GetCompanyAsync(companyId, trackChanges: false);
            if(comapny ==null)
            {
                _log.LogInfo($"Company with the Id {companyId} does not exist in the database");
                return NotFound();
            }

            var EmployeeDb = await _repo.Employee.GetEmployeeAsync(companyId, id, trackChanges: false);
            if (EmployeeDb == null)
            {
                _log.LogInfo($"Company with the Id {companyId} does not exist in the database");
                return NotFound();
            }

            var employee = _map.Map<EmployeeDTO>(EmployeeDb);
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployeeAsync(string companyId, [FromBody] AddEmployeeDTO employee)
        {
            if(employee == null)
            {
                _log.LogError("EmployeeDto object sent from client is null.");
                return BadRequest("EmployeeDto object is null");
            }

            var company = await _repo.Company.GetCompanyAsync(companyId, trackChanges: false);
            if(company == null)
            {
                _log.LogInfo($"Company with id: {companyId} doesn't exist in the database.");
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                _log.LogError("Invalid model state for the EmployeeForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var employeeEntity = _map.Map<Employee>(employee);
            _repo.Employee.AddEmployee(companyId, employeeEntity);
            await _repo.SaveAsync();

            var EmployeeReturn = _map.Map<EmployeeDTO>(employeeEntity);
            return CreatedAtRoute("companyId", new { 
                companyId = company.Id, id = EmployeeReturn.Id
                }, EmployeeReturn);


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeAsync(string companyId, string id)
        {
            var company = await _repo.Company.GetCompanyAsync(companyId, trackChanges: false);
            if (company == null) 
            {
                _log.LogInfo($"Company with id: {companyId} doesn't exist in the database.");
                return NotFound(); 
            } 
            
            var employeeForCompany = await _repo.Employee.GetEmployeeAsync(companyId, id, trackChanges: false);

            if (employeeForCompany == null)
            {
                _log.LogInfo($"Employee with id: {id} doesn't exist in the database.");
                return NotFound();
            } 
            
            _repo.Employee.DeleteEmployee(employeeForCompany);
            await _repo.SaveAsync(); 
            return NoContent(); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeAsync(string companyId, string id, [FromBody]UpdateEmployeeDTO employee)
        {
            if(employee == null)
            {
                _log.LogError("updateEmployeeDTO sent from client is null");
                return BadRequest("updateEmployeeDTO is null");
            }

            var company = await _repo.Company.GetCompanyAsync(companyId, trackChanges: false);
            if(company == null)
            {
                _log.LogInfo($"Company with id: {companyId} doesn't exist in the database.");
                return NotFound();
            }

            var employeeEntity = await _repo.Employee.GetEmployeeAsync(companyId, id, trackChanges: true);
            if(employeeEntity == null)
            {
                _log.LogInfo($"Employee with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _map.Map(employee, employeeEntity);
            await _repo.SaveAsync();

            return NoContent();
        }
    }
}
