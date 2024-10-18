using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
 // Asegúrate de tener instalado Newtonsoft.Json para JsonIgnore

namespace WebApplication1.Models
{
    public class Usuario
    {
        [Key]
        public int ID_Usuario { get; set; }

        [Required]
        [StringLength(100)]
        public string? Nombre_Completo { get; set; }

        [Required]
        [EmailAddress]
        public string? Correo { get; set; }

        // Esto evita que la contraseña sea devuelta en las respuestas
        [Required]
        public string? Contrasena { get; set; }

        [Phone]
        public string? Telefono { get; set; }

        public string? Direccion { get; set; }

        [Required]
        public string? Rol { get; set; } // 'Administrador' o 'Inquilino'

        public string? Codigo_Administracion { get; set; } // Solo para Administradores
        public string? Direccion_Propiedad { get; set; } // Solo para Inquilinos

        public DateTime Fecha_Registro { get; set; } = DateTime.Now;
    }
}
