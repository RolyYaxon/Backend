using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Administrador
    {
        [Key]
        public int ID_Administrador { get; set; }
        public string Nombre_Completo { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
    }
}
