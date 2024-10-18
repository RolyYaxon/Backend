using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Pago
    {
        [Key]
        public int ID_Pago { get; set; }

        [Required]
        public int ID_Contrato { get; set; } // Llave foránea hacia el contrato

        [Required]
        [DataType(DataType.Currency)]
        public decimal Monto_Pago { get; set; } // Monto del pago

        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha_Pago { get; set; } // Fecha del pago

        [Required]
        public int ID_Metodo { get; set; } 

        [Required]
        public string? Estado_Pago { get; set; } // 'Pagado', 'Pendiente', etc.

        public decimal Intereses_Mora { get; set; } // Intereses por mora, si aplican

        public string? Referencia_Transaccion { get; set; } // Código o referencia de la transacción

        public string Notas { get; set; } // Notas adicionales sobre el pago
    }
}
