using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly PasswordHasher<Usuario> _passwordHasher;

    public AuthController(ApplicationDbContext context)
    {
        _context = context;
        _passwordHasher = new PasswordHasher<Usuario>();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        Console.WriteLine(loginDto.Correo); // Agrega esto para verificar el valor de correo

        var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Correo == loginDto.Correo);

        if (usuario == null)
            return Unauthorized(new { message = "Correo o contraseña incorrectos" });

        var result = _passwordHasher.VerifyHashedPassword(usuario, usuario.Contrasena, loginDto.Contrasena);
        if (result == PasswordVerificationResult.Failed)
            return Unauthorized(new { message = "Correo o contraseña incorrectos" });

        return Ok(new { role = usuario.Rol });
    }
}

public class LoginDto
{
    public string Correo { get; set; }
    public string Contrasena { get; set; }
}