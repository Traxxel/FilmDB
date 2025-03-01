using Microsoft.AspNetCore.Mvc;
using FilmDB.DAL;
using FilmDB.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmDB.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SenderController : ControllerBase
    {
        private readonly FilmDBContext _context;

        public SenderController(FilmDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sender>>> GetSender()
        {
            return await _context.Sender.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sender>> GetSender(int id)
        {
            var sender = await _context.Sender.FindAsync(id);

            if (sender == null)
            {
                return NotFound();
            }

            return sender;
        }

        [HttpPost]
        public async Task<ActionResult<Sender>> PostSender(Sender sender)
        {
            _context.Sender.Add(sender);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSender), new { id = sender.ID }, sender);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSender(int id, Sender sender)
        {
            if (id != sender.ID)
            {
                return BadRequest();
            }

            _context.Entry(sender).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SenderExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSender(int id)
        {
            var sender = await _context.Sender.FindAsync(id);
            if (sender == null)
            {
                return NotFound();
            }

            _context.Sender.Remove(sender);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SenderExists(int id)
        {
            return _context.Sender.Any(e => e.ID == id);
        }
    }
} 