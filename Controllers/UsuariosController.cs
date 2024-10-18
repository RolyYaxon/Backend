using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;
using System.Net;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly PasswordHasher<Usuario> _passwordHasher;
        private readonly SmtpClient _smtpClient;

        public UsuariosController(ApplicationDbContext context, SmtpClient smtpClient)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<Usuario>();
            _smtpClient = smtpClient;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
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

        // POST: api/Usuarios (Registrar un usuario nuevo)
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            // Verificar si el correo ya está registrado
            if (await _context.Usuarios.AnyAsync(u => u.Correo == usuario.Correo))
            {
                return BadRequest(new { message = "El correo electrónico ya está registrado." });
            }

            // Hashear la contraseña antes de guardar
            usuario.Contrasena = _passwordHasher.HashPassword(usuario, usuario.Contrasena);

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            // Enviar un correo electrónico de confirmación
            await EnviarCorreoConfirmacion(usuario.Correo);

            return CreatedAtAction("GetUsuario", new { id = usuario.ID_Usuario }, usuario);
        }

        // PUT: api/Usuarios/5 (Actualizar un usuario existente)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.ID_Usuario)
            {
                return BadRequest("El ID no coincide con el usuario proporcionado.");
            }

            // Asegúrate de no cambiar la contraseña si no se proporciona una nueva
            var existingUser = await _context.Usuarios.FindAsync(id);
            if (existingUser == null)
            {
                return NotFound("Usuario no encontrado.");
            }

            if (!string.IsNullOrEmpty(usuario.Contrasena))
            {
                // Hashear la nueva contraseña
                existingUser.Contrasena = _passwordHasher.HashPassword(existingUser, usuario.Contrasena);
            }

            // Actualizar otros campos
            existingUser.Nombre_Completo = usuario.Nombre_Completo;
            existingUser.Correo = usuario.Correo;
            existingUser.Telefono = usuario.Telefono;
            existingUser.Direccion = usuario.Direccion;
            existingUser.Rol = usuario.Rol;
            existingUser.Codigo_Administracion = usuario.Codigo_Administracion;
            existingUser.Direccion_Propiedad = usuario.Direccion_Propiedad;

            _context.Entry(existingUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound("No se encontró el usuario para actualizar.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Usuarios/5 (Eliminar un usuario)
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

        // Verificar si un usuario existe por ID
        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.ID_Usuario == id);
        }

        // Método para enviar correo de confirmación
        private async Task EnviarCorreoConfirmacion(string correo)
        {
            var mensaje = new MailMessage();
            mensaje.To.Add(correo);
            mensaje.Subject = "Confirmación de registro";
            mensaje.Body = "¡Gracias por registrarte en nuestro sistema! Por favor, confirma tu correo electrónico.";
            mensaje.From = new MailAddress("tu-correo@gmail.com"); // Cambia esto a tu correo

            try
            {
                await _smtpClient.SendMailAsync(mensaje);
            }
            catch (SmtpException ex)
            {
                // Maneja el error del envío de correo
                Console.WriteLine($"Error al enviar el correo: {ex.Message}");
            }
        }
    }
}
