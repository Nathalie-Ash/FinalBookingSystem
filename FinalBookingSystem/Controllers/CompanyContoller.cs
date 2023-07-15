using AutoMapper;
using FinalBookingSystem.Resources;
using IDS.Core.Models;
using IDS.Services.Interfaces;
using IDSBookingSystem.Resources;

using Microsoft.AspNetCore.Mvc;

namespace IDSBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        // GET: api/Choices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        { 
            var companies = await _companyService.GetAllCompanies();
                
            return Ok(companies);
        }

        // GET: api/Choices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompanyById(int id)
        {
            var company = await _companyService.GetCompanyById(id);
            return Ok(company);
        }


        // PUT: api/Company/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(int id, [FromBody] CompanyDto updatedCompanyDto)
        {
            var existingCompany = await _companyService.GetCompanyById(id);

            if (existingCompany == null)
            {
                return NotFound(); // Entity not found, return appropriate response
            }

            // Update the entity with the new data
            existingCompany.Name = updatedCompanyDto.Name;
            existingCompany.Email = updatedCompanyDto.Email;
            existingCompany.Description = updatedCompanyDto.Description;
            existingCompany.Logo = updatedCompanyDto.Logo;
            existingCompany.Active = updatedCompanyDto.Active;

            // Save the changes
            await _companyService.UpdateCompany(existingCompany);

            return Ok(); // Updated successfully, return appropriate response
        }


        // POST: api/Choices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPost]
        public async Task<ActionResult<Company>> PostChoice(Company newcompany)
        {
            var choice = await _companyService.CreateCompany(newcompany);
            return Ok(choice);
        }*/
        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyDto companyDto)
        {
            // Map the DTO to the entity
            var company = new Company
            {
                Name = companyDto.Name,
                Email = companyDto.Email,
                Description = companyDto.Description,
                Logo = companyDto.Logo,
                Active = companyDto.Active
            };

            await _companyService.CreateCompany(company);

            return Ok(company);
        }

       /* [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id, ICompanyService _companyService)
        {
            if (id == 0)
                return BadRequest();

            var company = await _companyService.GetCompanyById(id);

            if (company == null)
                return NotFound();

            await _companyService.DeleteCompany(company);

            return NoContent();
        }*/
        /*  public CompanyController(ICompanyService companyService, IMapper mapper)
          {
              this._mapper = mapper;
              this._companyService = companyService;
          }


          [HttpGet("all")]
          public async Task<ActionResult<IEnumerable<CompanyResource>>> GetAllCompanies()
          {
              try
              {
                  var companies = await _companyService.GetAllWithCompany();
                  var companyResources = _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyResource>>(companies);

                  return Ok(companyResources);
              }
              catch (Exception ex)
              {
                  // Log the exception if needed
                  return StatusCode(500, "An error occurred while retrieving music resources.");
              }
          }
        */



    }
}
