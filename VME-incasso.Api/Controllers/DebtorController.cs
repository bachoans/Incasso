using Microsoft.AspNetCore.Mvc;
using VME.incasso.Business.Interfaces;
using VME.incasso.Data.Entities;

[ApiController]
[Route("api/[controller]")]
public class DebtorController : ControllerBase
{
    private readonly IDebtorService _debtorService;

    public DebtorController(IDebtorService debtorService)
    {
        _debtorService = debtorService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDebtorById(int id)
    {
        var debtor = await _debtorService.GetByIdAsync(id);
        if (debtor == null) return NotFound();
        return Ok(debtor);
    }

    [HttpGet("by-building/{buildingId}")]
    public async Task<IActionResult> GetDebtorsByBuilding(int buildingId)
    {
        var debtors = await _debtorService.GetDebtorsByBuildingAsync(buildingId);
        return Ok(debtors);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDebtor([FromBody] Debtor debtor)
    {
        var createdDebtor = await _debtorService.AddAsync(debtor);
        return CreatedAtAction(nameof(GetDebtorById), new { id = createdDebtor.Id }, createdDebtor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDebtor(int id, [FromBody] Debtor debtor)
    {
        if (id != debtor.Id) return BadRequest("ID mismatch.");
        await _debtorService.UpdateAsync(debtor);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDebtor(int id)
    {
        var debtor = await _debtorService.GetByIdAsync(id);
        if (debtor == null) return NotFound();
        await _debtorService.RemoveAsync(debtor);
        return NoContent();
    }
}