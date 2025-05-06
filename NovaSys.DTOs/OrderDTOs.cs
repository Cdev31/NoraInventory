using System.ComponentModel.DataAnnotations;
using prueba_tec.NovaSys.Models;

namespace prueba_tec.NovaSys.DTOs
{
    public class CreateOrderDTOs
    {
        [Required( ErrorMessage = "client es requerido")]
        public int client { get; set; }

        [Required( ErrorMessage = "state es requerido")]
        public int state { get; set; }

        [Required( ErrorMessage = "products son requeridos")]
        public List<ProductModel> products { get; set; }
    }

    public class FindOutputOrderDTOs
    {
        public int client { get; set; }
        public int state { get; set; }
        public List<ProductModel> products { get; set; }
    }
}