using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarmaciaApi.Models;
using FarmaciaApi.Models.Security;
using Microsoft.AspNetCore.Authorization;

namespace FarmaciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditoriasController : ControllerBase
    {
        private readonly FarmaciaDbContext _context;

        public AuditoriasController(FarmaciaDbContext context)
        {
            _context = context;
        }

        // GET: api/Auditorias
        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Auditoria>>> GetAuditorias()
        {
            return await _context.Auditorias.ToListAsync();
        }

        // GET: api/Auditorias/5
        //[Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Auditoria>> GetAuditoria(int id)
        {
            var auditoria = await _context.Auditorias.FindAsync(id);

            if (auditoria == null)
            {
                return NotFound();
            }

            return auditoria;
        }

        // PUT: api/Auditorias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuditoria(int id, Auditoria auditoria)
        {
            if (id != auditoria.IdAuditoria)
            {
                return BadRequest();
            }

            _context.Entry(auditoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuditoriaExists(id))
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

        // POST: api/Auditorias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<Auditoria>> PostAuditoria(Auditoria auditoria)
        {
            _context.Auditorias.Add(auditoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuditoria", new { id = auditoria.IdAuditoria }, auditoria);
        }

        // DELETE: api/Auditorias/5
        //[Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuditoria(int id)
        {
            var auditoria = await _context.Auditorias.FindAsync(id);
            if (auditoria == null)
            {
                return NotFound();
            }

            _context.Auditorias.Remove(auditoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuditoriaExists(int id)
        {
            return _context.Auditorias.Any(e => e.IdAuditoria == id);
        }
    }
}
