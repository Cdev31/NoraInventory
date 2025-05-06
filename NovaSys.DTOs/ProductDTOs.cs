using System.ComponentModel.DataAnnotations;

namespace prueba_tec.NovaSys.DTOs
{
    public class CreateProductDTOs
    {

        [Required(ErrorMessage = " nombre es requerido ")]
        [MaxLength(40)]
        public string name { get; set; }

        [Required(ErrorMessage = " precio es requerido")]
        [Range(typeof(decimal), "0.01", "9999.99", ErrorMessage = "Fuera de rango")]
        public decimal price { get; set; }

        [Required(ErrorMessage = "stock es requerido ")]
        [MinLength(0)]
        public int stock { get; set; }

        [Required(ErrorMessage = "state es requerido ")]
        public int state { get; set; }

        [Required(ErrorMessage = "stock es requerido ")]
        [MaxLength(200)]
        public string description { get; set; }
    }

    public class FindAllByStateDTOs
    {
        [Required(ErrorMessage = " state es requerido ")]
        public int state { get; set; }
    }

    public class SetIdDTOs
    {
        [Required]
        public int Id { get; set; }

    }

    public class UpdateProductDTOs
    {
        [Required(ErrorMessage = "Id es requerido")]
        public int Id { get; set; }

        [Required(ErrorMessage = " nombre es requerido ")]
        [MaxLength(40)]
        public string name { get; set; }

        [Required(ErrorMessage = " precio es requerido")]
        [Range(typeof(decimal), "0.01", "9999.99", ErrorMessage = "Fuera de rango")]
        public decimal price { get; set; }

        [Required(ErrorMessage = "state es requerido ")]
        public int state { get; set; }

        [Required(ErrorMessage = "stock es requerido ")]
        [MaxLength(200)]
        public string description { get; set; }
    }

    public class FindProductOuputDTOs
    {
        public int Id { get; set; }
        public string name { get; set; }

        public decimal price { get; set; }

        public int stock { get; set; }

        public string state { get; set; }

        public string description { get; set; }
    }
}