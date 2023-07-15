using IDS.Core.Interfaces;
using IDS.Core.Models;
using IDS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDS.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CompanyService(IUnitOfWork unitOfWork, ICompanyRepository companyRepository)
        {
            this._unitOfWork = unitOfWork;
            this._companyRepository = companyRepository;
        }

        public async Task<Company> CreateCompany(Company newCompany)
        {
            await _unitOfWork.Companies.AddAsync(newCompany);
            await _unitOfWork.CommitAsync();
            return newCompany;
        }


        public async Task UpdateCompany(Company company)
        {
            await _companyRepository.UpdateCompany(company);
        }

        public async Task<Company> GetCompanyById(int id)
        {
            return await _companyRepository.GetCompanyById(id);
        }

        public async Task DeleteCompany(Company company)
        {
            _unitOfWork.Companies.Delete(company);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await _unitOfWork.Companies.GetAllWithCompaniesAsync();
        }

        public Task<IEnumerable<Company>> GetCompaniesByCompanyId(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCompany(Company companyToBeUpdated, Company company)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCompany(Company companyToBeUpdated, Role reservation)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Reservation>> GetAllWithReservation()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Company>> GetAllWithCompany()
        {
            throw new NotImplementedException();
        }

        public Task UpdateCompany(int id, Company updatedCompany)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCompany(int id)
        {
            throw new NotImplementedException();
        }
    }
}
