﻿using AutoMapper;
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
        public IActionResult GetEmployeesForCompany(string companyId)
        {
            var company = _repo.Company.GetCompany(companyId, trackChanges: false);
            if (company == null)
            {
                _log.LogInfo($"Company with the Id {companyId} does not exist in the database");
                return NotFound();
            }
            else
            {
                var employeesFromDb = _repo.Employee.GetEmployees(companyId, trackChanges: false);

                var employessDto = _map.Map<IEnumerable<EmployeeDTO>>(employeesFromDb);

                return Ok(employessDto);              
            }
        }

        [HttpGet("{id}", Name = "companyId")]
        public IActionResult GetEmployeeForACompany(string companyId, string id)
        {
            var comapny = _repo.Company.GetCompany(companyId, trackChanges: false);
            if(comapny ==null)
            {
                _log.LogInfo($"Company with the Id {companyId} does not exist in the database");
                return NotFound();
            }

            var EmployeeDb = _repo.Employee.GetEmployee(companyId, id, trackChanges: false);
            if (EmployeeDb == null)
            {
                _log.LogInfo($"Company with the Id {companyId} does not exist in the database");
                return NotFound();
            }

            var employee = _map.Map<EmployeeDTO>(EmployeeDb);
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(string companyId, [FromBody] AddEmployeeDTO employee)
        {
            if(employee == null)
            {
                _log.LogError("EmployeeDto object sent from client is null.");
                return BadRequest("EmployeeDto object is null");
            }

            var company = _repo.Company.GetCompany(companyId, trackChanges: false);
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
            _repo.Save();

            var EmployeeReturn = _map.Map<EmployeeDTO>(employeeEntity);
            return CreatedAtRoute("companyId", new { 
                companyId = company.Id, id = EmployeeReturn.Id
                }, EmployeeReturn);


        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(string companyId, string id)
        {
            var company = _repo.Company.GetCompany(companyId, trackChanges: false);
            if (company == null) 
            {
                _log.LogInfo($"Company with id: {companyId} doesn't exist in the database.");
                return NotFound(); 
            } 
            
            var employeeForCompany = _repo.Employee.GetEmployee(companyId, id, trackChanges: false);
            if (employeeForCompany == null)
            {
                _log.LogInfo($"Employee with id: {id} doesn't exist in the database.");
                return NotFound();
            } 
            
            _repo.Employee.DeleteEmployee(employeeForCompany);
            _repo.Save(); 
            return NoContent(); 
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(string companyId, string id, [FromBody]UpdateEmployeeDTO employee)
        {
            if(employee == null)
            {
                _log.LogError("updateEmployeeDTO sent from client is null");
                return BadRequest("updateEmployeeDTO is null");
            }

            var company = _repo.Company.GetCompany(companyId, trackChanges: false);
            if(company == null)
            {
                _log.LogInfo($"Company with id: {companyId} doesn't exist in the database.");
                return NotFound();
            }

            var employeeEntity = _repo.Employee.GetEmployee(companyId, id, trackChanges: true);
            if(employeeEntity == null)
            {
                _log.LogInfo($"Employee with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _map.Map(employee, employeeEntity);
            _repo.Save();

            return NoContent();
        }
    }
}
