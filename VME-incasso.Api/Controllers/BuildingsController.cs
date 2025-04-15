using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VME.incasso.Business.Interfaces;
using VME.incasso.Data.DTOs;
using VME.incasso.Data.Entities;

[ApiController]
[Route("api/[controller]")]
public class BuildingsController : ControllerBase
{
    private readonly IBuildingService _buildingService;

    public BuildingsController(IBuildingService buildingService)
    {
        _buildingService = buildingService;
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var building = await _buildingService.GetByIdAsync(id);
        if (building == null)
        {
            return NotFound();
        }

        // Map entity to DTO
        var buildingDto = new BuildingDto
        {
            Id = building.Id,
            CompanyId = building.CompanyId,
            Name = building.Name,
            Address = building.Address,
            City = building.City,
            PostalCode = building.PostalCode,
            BankAccount = building.BankAccount,
            InterestRate = building.InterestRate,
            PenaltyRate = building.PenaltyRate,
            CourtJurisdiction = building.CourtJurisdiction
        };

        return Ok(buildingDto);
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var buildings = await _buildingService.GetAuthorizedBuildingsAsync();

        // Map entities to DTOs
        var buildingDtos = buildings.Select(building => new BuildingDto
        {
            Id = building.Id,
            CompanyId = building.CompanyId,
            Name = building.Name,
            Address = building.Address,
            City = building.City,
            PostalCode = building.PostalCode,
            BankAccount = building.BankAccount,
            InterestRate = building.InterestRate,
            PenaltyRate = building.PenaltyRate,
            CourtJurisdiction = building.CourtJurisdiction
        });

        return Ok(buildingDtos);
    }

    [HttpPost]
    public async Task<IActionResult> Add(BuildingDto buildingDto)
    {
        // Map DTO to entity
        var building = new Building
        {
            Name = buildingDto.Name,
            Address = buildingDto.Address,
            City = buildingDto.City,
            PostalCode = buildingDto.PostalCode,
            BankAccount = buildingDto.BankAccount,
            InterestRate = buildingDto.InterestRate,
            PenaltyRate = buildingDto.PenaltyRate,
            CourtJurisdiction = buildingDto.CourtJurisdiction
        };

        var addedBuilding = await _buildingService.AddAuthorizedBuildingAsync(building);

        // Map entity to DTO for the response
        var addedBuildingDto = new BuildingDto
        {
            Id = addedBuilding.Id,
            CompanyId = addedBuilding.CompanyId,
            Name = addedBuilding.Name,
            Address = addedBuilding.Address,
            City = addedBuilding.City,
            PostalCode = addedBuilding.PostalCode,
            BankAccount = addedBuilding.BankAccount,
            InterestRate = addedBuilding.InterestRate,
            PenaltyRate = addedBuilding.PenaltyRate,
            CourtJurisdiction = addedBuilding.CourtJurisdiction
        };

        return CreatedAtAction(nameof(GetByIdAsync), new { id = addedBuildingDto.Id }, addedBuildingDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, BuildingDto buildingDto)
    {
        if (id != buildingDto.Id)
        {
            return BadRequest("Building ID mismatch.");
        }

        // Map DTO to entity
        var building = new Building
        {
            Id = buildingDto.Id,
            CompanyId = buildingDto.CompanyId,
            Name = buildingDto.Name,
            Address = buildingDto.Address,
            City = buildingDto.City,
            PostalCode = buildingDto.PostalCode,
            BankAccount = buildingDto.BankAccount,
            InterestRate = buildingDto.InterestRate,
            PenaltyRate = buildingDto.PenaltyRate,
            CourtJurisdiction = buildingDto.CourtJurisdiction
        };

        await _buildingService.UpdateAuthorizedBuildingAsync(building);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _buildingService.DeleteAuthorizedBuildingAsync(id);
        return NoContent();
    }
}
