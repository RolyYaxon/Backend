using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Mail;


var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de la clave secreta para JWT
var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtConfig:Secret"]);

// Agrega el DbContext y configura la conexi�n con la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Habilitar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Configuraci�n de JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});

// Agregar Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API de Alquileres", Version = "v1" });
});

// Agregar el servicio de env�o de correos
builder.Services.AddTransient<SmtpClient>((serviceProvider) =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    return new SmtpClient
    {
        Host = configuration["Smtp:Host"],
        Port = int.Parse(configuration["Smtp:Port"]),
        EnableSsl = bool.Parse(configuration["Smtp:EnableSsl"]),
        Credentials = new NetworkCredential(
            configuration["Smtp:UserName"],
            configuration["Smtp:Password"])
    };
});

// Agrega los servicios a los controladores
builder.Services.AddControllers();
builder.Services.AddTransient<EmailService>();
var app = builder.Build();

// Habilitar CORS
app.UseCors("AllowAll");

// Configura el middleware para la autenticaci�n y autorizaci�n
app.UseAuthentication();
app.UseAuthorization();

// Configura el middleware para el entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    // Habilitar Swagger solo en desarrollo
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Alquileres v1");
        c.RoutePrefix = string.Empty; // Hace que swagger est� disponible en la ra�z
    });
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.Run();
