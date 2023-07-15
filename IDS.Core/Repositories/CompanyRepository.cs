using IDS.Core.Interfaces;
using IDS.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.Core.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(IdsbookingSystemContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Company>> GetAllWithCompaniesAsync()
        {
            return await MyDbContext.Companies.ToListAsync();
        }

        public Task<Company> GetWithCompaniesByIdAsync(int id)
        {
            return MyDbContext.Companies.SingleOrDefaultAsync(a => a.Id == id);
        }

/*        public async Task<IEnumerable<Company>> GetAllWithCompaniesByCompanyIdAsync(int id)
        {
            return await MyDbContext.Companies.Where(c => c.CompanyId == id).ToListAsync();
        }*/

        public async Task<Company> CreateCompany(Company newCompany)
        {
            await MyDbContext.Companies.AddAsync(newCompany);
            await MyDbContext.SaveChangesAsync();
            return newCompany;
        }

        public async Task UpdateCompany(Company company)
        {
            MyDbContext.Companies.Update(company);
            await MyDbContext.SaveChangesAsync();
        }

        public async Task DeleteCompany(Company company)
        {
            MyDbContext.Companies.Remove(company);
            await MyDbContext.SaveChangesAsync();
        }

        public async Task<Company> GetCompanyById(int id)
        {
            return await MyDbContext.Companies.FindAsync(id);
        }

        public Task Insert(Company newCompany)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Company>> GetAllWithCompaniesByCompanyIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        private IdsbookingSystemContext MyDbContext
        {
            get { return Context as IdsbookingSystemContext; }
        }
    }
}
