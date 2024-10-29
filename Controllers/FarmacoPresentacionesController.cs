using System;
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
    public class FarmacoPresentacionesController : ControllerBase
    {
        private readonly FarmaciaDbContext _context;

        public FarmacoPresentacionesController(FarmaciaDbContext context)
        {
            _context = context;
        }

        // GET: api/FarmacoPresentacions
        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FarmacoPresentacion>>> GetLoteFarmacoDetalles()
        {
            return await _context.LoteFarmacoDetalles.ToListAsync();
        }

        // GET: api/FarmacoPresentacions/5
        //[Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<FarmacoPresentacion>> GetFarmacoPresentacion(int id)
        {
            var farmacoPresentacion = await _context.LoteFarmacoDetalles.FindAsync(id);

            if (farmacoPresentacion == null)
            {
                return NotFound();
            }

            return farmacoPresentacion;
        }

        // PUT: api/FarmacoPresentacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFarmacoPresentacion(int id, FarmacoPresentacion farmacoPresentacion)
        {
            if (id != farmacoPresentacion.IdLoteFarmacoDetalles)
            {
                return BadRequest();
            }

            _context.Entry(farmacoPresentacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FarmacoPresentacionExists(id))
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

        // POST: api/FarmacoPresentacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<FarmacoPresentacion>> PostFarmacoPresentacion(FarmacoPresentacion farmacoPresentacion)
        {
            _context.LoteFarmacoDetalles.Add(farmacoPresentacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFarmacoPresentacion", new { id = farmacoPresentacion.IdLoteFarmacoDetalles }, farmacoPresentacion);
        }

        // DELETE: api/FarmacoPresentacions/5
        //[Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFarmacoPresentacion(int id)
        {
            var farmacoPresentacion = await _context.LoteFarmacoDetalles.FindAsync(id);
            if (farmacoPresentacion == null)
            {
                return NotFound();
            }

            _context.LoteFarmacoDetalles.Remove(farmacoPresentacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FarmacoPresentacionExists(int id)
        {
            return _context.LoteFarmacoDetalles.Any(e => e.IdLoteFarmacoDetalles == id);
        }
    }
}
