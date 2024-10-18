using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Propiedad
    {
        [Key]
        public int ID_Propiedad { get; set; }
        public int Tipo_Propiedad { get; set; }
        public int Numero_Habitaciones { get; set; }
        public int Numero_Banos { get; set; }
        public decimal Area { get; set; }
        public decimal Precio_Alquiler { get; set; }
        public decimal Deposito_Requerido { get; set; }
        public int Estado_Propiedad { get; set; }
        public string Ubicacion { get; set; }
        public string Coordenadas_GPS { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_Registro { get; set; }
    }
}
