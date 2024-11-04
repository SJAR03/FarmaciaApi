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
    public class LoteFarmacosController : ControllerBase
    {
        private readonly FarmaciaDbContext _context;

        public LoteFarmacosController(FarmaciaDbContext context)
        {
            _context = context;
        }

        // GET: api/LoteFarmacos
        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoteFarmaco>>> GetLoteFarmacos()
        {
            return await _context.LoteFarmacos.ToListAsync();
        }

        // GET: api/LoteFarmacos/5
        //[Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<LoteFarmaco>> GetLoteFarmaco(int id)
        {
            var loteFarmaco = await _context.LoteFarmacos.FindAsync(id);

            if (loteFarmaco == null)
            {
                return NotFound();
            }

            return loteFarmaco;
        }

        // PUT: api/LoteFarmacos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoteFarmaco(int id, LoteFarmacoUpdateDTO loteFarmaco)
        {
            var existingLotefarmaco = await _context.LoteFarmacos.FindAsync(id);

            if (existingLotefarmaco == null)
            {
                return NotFound();
            }

            existingLotefarmaco.Nombre = loteFarmaco.Nombre;
            existingLotefarmaco.Descripcion = loteFarmaco.Descripcion;
            existingLotefarmaco.Cantidad = loteFarmaco.Cantidad;
            existingLotefarmaco.Estado = loteFarmaco.Estado;
            existingLotefarmaco.IdUsuarioModificacion = loteFarmaco.IdUsuarioModificacion;
            existingLotefarmaco.FechaModificacion = loteFarmaco.FechaModificacion;

            _context.Entry(existingLotefarmaco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoteFarmacoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(existingLotefarmaco);
        }

        // POST: api/LoteFarmacos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<LoteFarmaco>> PostLoteFarmaco(LoteFarmacoCreateDTO loteFarmaco)
        {

            var lotefarmacoObj = new LoteFarmaco
            {
                Nombre = loteFarmaco.Nombre,
                Descripcion = loteFarmaco.Descripcion,
                Cantidad = loteFarmaco.Cantidad,
                Estado = loteFarmaco.Estado,
                IdUsuarioCreacion = loteFarmaco.IdUsuarioCreacion,
                FechaCreacion = loteFarmaco.FechaCreacion,
                IdUsuarioModificacion = loteFarmaco.IdUsuarioModificacion,
                FechaModificacion = loteFarmaco.FechaModificacion
            };

            _context.LoteFarmacos.Add(lotefarmacoObj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoteFarmaco", new { id = lotefarmacoObj.IdLoteFarmaco }, lotefarmacoObj);
        }

        // DELETE: api/LoteFarmacos/5
        //[Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoteFarmaco(int id)
        {
            var loteFarmaco = await _context.LoteFarmacos.FindAsync(id);
            if (loteFarmaco == null)
            {
                return NotFound();
            }

            _context.LoteFarmacos.Remove(loteFarmaco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoteFarmacoExists(int id)
        {
            return _context.LoteFarmacos.Any(e => e.IdLoteFarmaco == id);
        }
    }
}
