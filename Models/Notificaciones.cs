using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Notificacion
    {
        [Key]
        public int ID_Notificacion { get; set; }

        [Required]
        public int Tipo_Notificacion { get; set; } // Tipo de notificación (puede ser un número que refiera a tipos predefinidos)

        [DataType(DataType.Date)]
        public DateTime Fecha_Envio { get; set; } = DateTime.Now;

        public int? ID_Destinatario_Admin { get; set; } // Puede ser nulo si no hay destinatario admin
        public int? ID_Destinatario_Inquilino { get; set; } // Puede ser nulo si no hay destinatario inquilino

        [Required]
        public string Contenido { get; set; } // El mensaje de la notificación

        [Required]
        public string Estado_Notificacion { get; set; } // 'Enviada', 'Pendiente', etc.

        [Required]
        public string Prioridad { get; set; } // 'Alta', 'Media', 'Baja'

        [Required]
        public string Estado_Lectura { get; set; } // 'Leído', 'No leído'
    }
}
