using System.Collections.Generic;
using WebApi.Entities.Models;

namespace WebApi.Contracts
{
    public interface ICompanyRepository
    {
        public IEnumerable<Company> GetAllCompanies(bool trackChanges);
    }
}
