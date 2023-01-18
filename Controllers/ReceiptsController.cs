using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Receipt_Generator.Data;
using Receipt_Generator.Models;

namespace Receipt_Generator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptsController : Controller
    {
        private readonly ReceiptDbContext _context;

        public ReceiptsController(ReceiptDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receipt>>> GetReceipt()
        {
            if (_context.Receipt == null)
            {
                return NotFound();
            }
            return await _context.Receipt.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Receipt>> Get(int id)
        {
            if (_context.Receipt == null)
            {
                return NotFound();
            }
            var lote = await _context.Receipt.FindAsync(id);

            if (lote == null)
            {
                return NotFound();
            }

            return lote;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Receipt receipt)
        {
            if (id != receipt.Id)
            {
                return BadRequest();
            }

            _context.Entry(receipt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Receipt>> Post(Receipt receipt)
        {
            if (_context.Receipt == null)
            {
                return Problem("Entity set 'PharmacyBAContext.Lote'  is null.");
            }
            _context.Receipt.Add(receipt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReceipt", new { id = receipt.Id }, receipt);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Receipt == null)
            {
                return NotFound();
            }
            var lote = await _context.Receipt.FindAsync(id);
            if (lote == null)
            {
                return NotFound();
            }

            _context.Receipt.Remove(lote);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoteExists(int id)
        {
            return (_context.Receipt?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
