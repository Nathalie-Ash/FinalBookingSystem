using IDS.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDS.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAllCompanies();
        Task<Company> GetCompanyById(int id);
        Task<IEnumerable<Company>> GetCompaniesByCompanyId(int id);
        Task<Company> CreateCompany(Company newCompany);
        Task UpdateCompany(Company existingCompany);
        Task DeleteCompany(int id);
        Task<IEnumerable<Company>> GetAllWithCompany();
    }
}
