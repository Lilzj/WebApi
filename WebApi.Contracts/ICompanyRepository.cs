using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Entities.Models;

namespace WebApi.Contracts
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges);
        Task<Company> GetCompanyAsync(string companyId, bool trackChanges);
        void AddCompany(Company company);
        Task<IEnumerable<Company>> GetByIdsAsync(IEnumerable<string> ids, bool trackChanges);
        void DeleteCompany(Company company);
    }
}
