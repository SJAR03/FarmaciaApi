﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarmaciaApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace FarmaciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresentacionesController : ControllerBase
    {
        private readonly FarmaciaDbContext _context;

        public PresentacionesController(FarmaciaDbContext context)
        {
            _context = context;
        }

        // GET: api/Presentaciones
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Presentacion>>> GetPresentaciones()
        {
            return await _context.Presentaciones.ToListAsync();
        }

        // GET: api/Presentaciones/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Presentacion>> GetPresentacion(int id)
        {
            var presentacion = await _context.Presentaciones.FindAsync(id);

            if (presentacion == null)
            {
                return NotFound();
            }

            return presentacion;
        }

        // PUT: api/Presentaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPresentacion(int id, Presentacion presentacion)
        {
            if (id != presentacion.IdPresentacion)
            {
                return BadRequest();
            }

            _context.Entry(presentacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PresentacionExists(id))
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

        // POST: api/Presentaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Presentacion>> PostPresentacion(Presentacion presentacion)
        {
            _context.Presentaciones.Add(presentacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPresentacion", new { id = presentacion.IdPresentacion }, presentacion);
        }

        // DELETE: api/Presentaciones/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePresentacion(int id)
        {
            var presentacion = await _context.Presentaciones.FindAsync(id);
            if (presentacion == null)
            {
                return NotFound();
            }

            _context.Presentaciones.Remove(presentacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PresentacionExists(int id)
        {
            return _context.Presentaciones.Any(e => e.IdPresentacion == id);
        }
    }
}
