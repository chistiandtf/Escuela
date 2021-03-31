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
    [Route("Representantantes")]
    [ApiController]
    public class RepresentantesController : ControllerBase
    {
        private readonly EscolarContext _context;

        public RepresentantesController(EscolarContext context)
        {
            _context = context;
        }

        // GET: api/Representantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Representante>>> GetRepresentantes()
        {
            return await _context.Representantes.ToListAsync();
        }

        // GET: api/Representantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Representante>> GetRepresentante(int id)
        {
            var representante = await _context.Representantes.FindAsync(id);

            if (representante == null)
            {
                return NotFound();
            }

            return representante;
        }

        // PUT: api/Representantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepresentante(int id, Representante representante)
        {
            if (id != representante.Id)
            {
                return BadRequest();
            }

            _context.Entry(representante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepresentanteExists(id))
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

        // POST: api/Representantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Representante>> PostRepresentante(Representante representante)
        {
            _context.Representantes.Add(representante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRepresentante", new { id = representante.Id }, representante);
        }

        // DELETE: api/Representantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepresentante(int id)
        {
            var representante = await _context.Representantes.FindAsync(id);
            if (representante == null)
            {
                return NotFound();
            }

            _context.Representantes.Remove(representante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RepresentanteExists(int id)
        {
            return _context.Representantes.Any(e => e.Id == id);
        }
    }
}
