using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarmaciaApi.Models.Security;
using FarmaciaApi.Models;
using Microsoft.AspNetCore.Authorization;
using FarmaciaApi.DTOs.Create;
using FarmaciaApi.DTOs.Update;

namespace FarmaciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly FarmaciaDbContext _context;

        public UsuariosController(FarmaciaDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        /// <summary>
        /// Return the info of all users
        /// </summary>
        /// <remarks>Remeber authorize</remarks>
        /// <response code="200">User info retrieved</response>
        /// <response code="401">Not authorized</response>
        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
        //[Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        /// <summary>
        /// Update user info
        /// </summary>
        /// <remarks>Remeber authorize</remarks>
        /// <response code="200">User info updated</response>
        /// <response code="401">Not authorized</response>
        //[Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, [FromBody] UsuarioUpdateDTO usuario)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuarioExistente = await _context.Usuarios.FindAsync(id);

            if (usuarioExistente == null)
            {
                return NotFound("Usuario no encontrado");
            }

            // Actualizar solo las propiedades que tienen un valor
            if (!string.IsNullOrEmpty(usuario.Username))
            {
                usuarioExistente.Username = usuario.Username;
            }

            if (!string.IsNullOrEmpty(usuario.Nombre))
            {
                usuarioExistente.Nombre = usuario.Nombre;
            }

            if (!string.IsNullOrEmpty(usuario.Correo))
            {
                usuarioExistente.Correo = usuario.Correo;
            }

            _context.Usuarios.Update(usuarioExistente);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Usuario modificado correctamente");
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(int id, [FromBody] UsuarioChangePwdDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound("Usuario no encontrado");
            }

            // Verificar la contraseña actual
            using (var hmac = new System.Security.Cryptography.HMACSHA512(usuario.PasswordSalt))
            {
                var hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(dto.CurrentPassword));
                var currentPasswordHash = Convert.ToBase64String(hash);

                if (currentPasswordHash != usuario.Pwd)
                {
                    return BadRequest("Contraseña actual incorrecta");
                }

                // Verificar si la nueva contraseña es la misma que la actual
                var newHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(dto.NewPassword));
                var newPasswordHashCheck = Convert.ToBase64String(newHash);

                if (currentPasswordHash == newPasswordHashCheck)
                {
                    return BadRequest("La nueva contraseña no puede ser igual a la actual");
                }
            }

            // Crear nuevo hash y salt para la nueva contraseña
            string newPasswordHash;
            byte[] newPasswordSalt;
            CreatePasswordHash(dto.NewPassword, out newPasswordHash, out newPasswordSalt);

            usuario.Pwd = newPasswordHash;
            usuario.PasswordSalt = newPasswordSalt;

            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();

            return Ok("Contraseña cambiada correctamente");
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        ////[Authorize]
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(UsuarioCreateDTO usuarioCreate)
        {

            string passwordHash;
            byte[] passwordSalt;
            CreatePasswordHash(usuarioCreate.Pwd, out passwordHash, out passwordSalt);

            var usuario = new Usuario
            {
                Username = usuarioCreate.Username,
                Pwd = passwordHash,
                PasswordSalt = passwordSalt,
                Nombre = usuarioCreate.Nombre,
                Correo = usuarioCreate.Correo,
                Estado = 1
            };            

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.IdUsuario }, usuario);
        }

        private void CreatePasswordHash(string password, out string passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                var hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                passwordHash = Convert.ToBase64String(hash);
            }
        }

        // DELETE: api/Usuarios/5
        //[Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.IdUsuario == id);
        }
    }
}
