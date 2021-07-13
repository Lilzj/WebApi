using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Contracts;

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
                return Ok(employeesFromDb);
            }
        }
    }
}
