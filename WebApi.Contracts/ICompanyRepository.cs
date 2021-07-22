using System;
using System.Collections.Generic;
using WebApi.Entities.Models;

namespace WebApi.Contracts
{
    public interface ICompanyRepository
    {
        public IEnumerable<Company> GetAllCompanies(bool trackChanges);
        Company GetCompany(string companyId, bool trackChanges);
        void AddCompany(Company company);
        IEnumerable<Company> GetByIds(IEnumerable<string> ids, bool trackChanges);
        void DeleteCompany(Company company);
    }
}
