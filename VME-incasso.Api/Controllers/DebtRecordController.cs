using Microsoft.AspNetCore.Mvc;
using VME.incasso.Business.Interfaces;
using VME.incasso.Data.Entities;

[ApiController]
[Route("api/[controller]")]
public class DebtRecordController : ControllerBase
{
    private readonly IDebtRecordService _debtRecordService;

    public DebtRecordController(IDebtRecordService debtRecordService)
    {
        _debtRecordService = debtRecordService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDebtRecordById(int id)
    {
        var debtRecord = await _debtRecordService.GetByIdAsync(id);
        if (debtRecord == null) return NotFound();
        return Ok(debtRecord);
    }

    [HttpGet("by-debtor/{debtorId}")]
    public async Task<IActionResult> GetDebtRecordsByDebtor(int debtorId)
    {
        var debtRecords = await _debtRecordService.GetDebtRecordsByDebtorAsync(debtorId);
        return Ok(debtRecords);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDebtRecord([FromBody] DebtRecord debtRecord)
    {
        var createdDebtRecord = await _debtRecordService.AddAsync(debtRecord);
        return CreatedAtAction(nameof(GetDebtRecordById), new { id = createdDebtRecord.Id }, createdDebtRecord);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDebtRecord(int id, [FromBody] DebtRecord debtRecord)
    {
        if (id != debtRecord.Id) return BadRequest("ID mismatch.");
        await _debtRecordService.UpdateAsync(debtRecord);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDebtRecord(int id)
    {
        var debtRecord = await _debtRecordService.GetByIdAsync(id);
        if (debtRecord == null) return NotFound();
        await _debtRecordService.RemoveAsync(debtRecord);
        return NoContent();
    }
}
