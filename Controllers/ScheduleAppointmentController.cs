using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ScheduleAppointmentController : ControllerBase
{
    private readonly EmailService _emailService;

    public ScheduleAppointmentController(EmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost("schedule")]
    public async Task<IActionResult> ScheduleAppointment([FromBody] AppointmentRequest request)
    {
        // Verificar si el request es válido
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Aquí añadimos Console.WriteLine para depurar los datos recibidos
        Console.WriteLine($"Email recibido: {request.Email}");
        Console.WriteLine($"Fecha recibida: {request.Date}");
        Console.WriteLine($"Hora recibida: {request.Time}");

        try
        {
            // Lógica para agendar la cita (por ejemplo, guardar en la base de datos si es necesario)

            // Enviar el correo de confirmación
            string subject = "Confirmación de cita";
            string body = $"<p>Hola,</p><p>Tu cita ha sido agendada para el {request.Date} a las {request.Time}.</p>";
            await _emailService.SendEmailAsync(request.Email, subject, body);

            // Confirmación de éxito
            Console.WriteLine("Correo enviado exitosamente.");

            return Ok(new { message = "Cita agendada y correo enviado con éxito." });
        }
        catch (Exception ex)
        {
            // Imprimir el error en consola
            Console.WriteLine($"Error al agendar la cita: {ex.Message}");

            return StatusCode(500, new { message = "Error al agendar la cita.", error = ex.Message });
        }
    }
}

public class AppointmentRequest
{
    public string Email { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
}
