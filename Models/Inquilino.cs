using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Inquilino
    {
        [Key]
        public int ID_Inquilino { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre_Completo { get; set; }

        [Required]
        [EmailAddress]
        public string Informacion_Contacto { get; set; }

        [Required]
        [StringLength(50)]
        public string Documentos { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha_Registro { get; set; } = DateTime.Now;

        [Required]
        [StringLength(20)]
        public string Estado_Inquilino { get; set; } // 'Activo' o 'Inactivo'
    }
}
