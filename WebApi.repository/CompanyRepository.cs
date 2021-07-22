using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(x => x.Name)
            .ToListAsync();

        public async Task<IEnumerable<Company>> GetByIdsAsync(IEnumerable<string> ids, bool trackChanges) =>
            await FindByCondition(c => ids.Contains(c.Id), trackChanges)
            .ToListAsync();

        public async Task<Company> GetCompanyAsync(string companyId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(companyId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
