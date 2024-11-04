using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarmaciaApi.Models;
using Microsoft.AspNetCore.Authorization;
using FarmaciaApi.DTOs.Update;
using FarmaciaApi.DTOs.Create;

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
            return await _context.LoteFarmacoDetalles
                .Include(x => x.LoteFarmaco)
                .Include(x => x.Presentacion)
                    .ThenInclude(p => p.Medidas)
                .Include(x => x.Presentacion)
                    .ThenInclude(p => p.Dosificacion)
                .ToListAsync();
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
        public async Task<IActionResult> PutFarmacoPresentacion(int id, FarmacoPresentacionUpdateDTO farmacoPresentacion)
        {
            var existingFarmacoPresentacion = await _context.LoteFarmacoDetalles.FindAsync(id);

            if (existingFarmacoPresentacion == null)
            {
                return NotFound();
            }

            existingFarmacoPresentacion.Estado = farmacoPresentacion.Estado;
            existingFarmacoPresentacion.IdLoteFarmaco = farmacoPresentacion.IdLoteFarmaco;
            existingFarmacoPresentacion.IdPresentacion = farmacoPresentacion.IdPresentacion;
            existingFarmacoPresentacion.IdUsuarioModificacion = farmacoPresentacion.IdUsuarioModificacion;
            existingFarmacoPresentacion.FechaModificacion = farmacoPresentacion.FechaModificacion;

            _context.Entry(existingFarmacoPresentacion).State = EntityState.Modified;

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

            return Ok(existingFarmacoPresentacion);
        }

        // POST: api/FarmacoPresentacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<FarmacoPresentacion>> PostFarmacoPresentacion(FarmacoPresentacionCreateDTO farmacoPresentacion)
        {
            var farmacopresentacionObj = new FarmacoPresentacion
            {
                Estado = farmacoPresentacion.Estado,
                IdLoteFarmaco = farmacoPresentacion.IdLoteFarmaco,
                IdPresentacion = farmacoPresentacion.IdPresentacion,
                IdUsuarioCreacion = farmacoPresentacion.IdUsuarioCreacion,
                FechaCreacion = farmacoPresentacion.FechaCreacion,
                IdUsuarioModificacion = farmacoPresentacion.IdUsuarioModificacion,
                FechaModificacion = farmacoPresentacion.FechaModificacion
            };

            _context.LoteFarmacoDetalles.Add(farmacopresentacionObj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFarmacoPresentacion", new { id = farmacopresentacionObj.IdLoteFarmacoDetalles }, farmacopresentacionObj);
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
