using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Contracts;
using WebApi.Entities;
using WebApi.Entities.Models;

namespace WebApi.repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void AddCompany(Company company) => Create(company);

        public void DeleteCompany(Company company) => Delete(company);

        public IEnumerable<Company> GetAllCompanies(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(x => x.Name)
            .ToList();

        public IEnumerable<Company> GetByIds(IEnumerable<string> ids, bool trackChanges) =>
            FindByCondition(c => ids.Contains(c.Id), trackChanges)
            .ToList();

        public Company GetCompany(string companyId, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(companyId), trackChanges)
            .SingleOrDefault();
    }
}
