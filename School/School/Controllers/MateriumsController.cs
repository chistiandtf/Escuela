using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Models;

namespace School.Controllers
{
    [Route("Materia")]
    [ApiController]
    public class MateriumsController : ControllerBase
    {
        private readonly EscolarContext _context;

        public MateriumsController(EscolarContext context)
        {
            _context = context;
        }

        // GET: api/Materiums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Materium>>> GetMateria()
        {
            return await _context.Materia.ToListAsync();
        }

        // GET: api/Materiums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Materium>> GetMaterium(int id)
        {
            var materium = await _context.Materia.FindAsync(id);

            if (materium == null)
            {
                return NotFound();
            }

            return materium;
        }

        // PUT: api/Materiums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterium(int id, Materium materium)
        {
            if (id != materium.Idmateria)
            {
                return BadRequest();
            }

            _context.Entry(materium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MateriumExists(id))
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

        // POST: api/Materiums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Materium>> PostMaterium(Materium materium)
        {
            _context.Materia.Add(materium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterium", new { id = materium.Idmateria }, materium);
        }

        // DELETE: api/Materiums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterium(int id)
        {
            var materium = await _context.Materia.FindAsync(id);
            if (materium == null)
            {
                return NotFound();
            }

            _context.Materia.Remove(materium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MateriumExists(int id)
        {
            return _context.Materia.Any(e => e.Idmateria == id);
        }
    }
}
