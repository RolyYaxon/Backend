using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Contrato
    {
        [Key]
        public int ID_Contrato { get; set; }

        [Required]
        public int ID_Propiedad { get; set; }  // Llave foránea (Foreign Key)

        [Required]
        public int ID_Inquilino { get; set; }  // Llave foránea (Foreign Key)

        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha_Inicio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha_Finalizacion { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Monto_Alquiler { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Deposito { get; set; }

        [Required]
        [StringLength(500)]
        public string Condiciones { get; set; }

        [Required]
        [StringLength(50)]
        public string Estado_Contrato { get; set; } // Estado puede ser "Activo" o "Finalizado"
    }
}
