using Microsoft.AspNetCore.Mvc;
using VME.incasso.Business.Interfaces;
using VME.incasso.Data.Entities;

[ApiController]
[Route("api/[controller]")]
public class CompaniesController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompaniesController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var company = await _companyService.GetByIdAsync(id);
        if (company == null)
        {
            return NotFound();
        }
        return Ok(company);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var companies = await _companyService.GetAllAsync();
        return Ok(companies);
    }

    [HttpPost]
    public async Task<IActionResult> Add(Company company)
    {
        var addedCompany = await _companyService.AddAsync(company);
        return CreatedAtAction(nameof(GetById), new { id = addedCompany.Id }, addedCompany);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Company company)
    {
        if (id != company.Id) return BadRequest();

        await _companyService.UpdateAsync(company);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var company = await _companyService.GetByIdAsync(id);
        if (company == null) return NotFound();

        await _companyService.RemoveAsync(company);
        return NoContent();
    }

    [HttpGet("with-users")]
    public async Task<IActionResult> GetCompaniesWithUsers()
    {
        var companies = await _companyService.GetCompaniesWithUsersAsync();
        return Ok(companies);
    }
}
