using System.ComponentModel.DataAnnotations;

namespace prueba_tec.NovaSys.DTOs
{
    public class CreateClientDTOs
    {
        [Required(ErrorMessage = "firstname es requerido")]
        [MaxLength(10)]
        public string firstname { get; set; }

        [Required(ErrorMessage = " surname es requerido")]
        [MaxLength(10)]
        public string surname { get; set; }

        [Required(ErrorMessage = "email es requerido")]
        [EmailAddress(ErrorMessage = "Formato invalido")]
        public string email { get; set; }

        [Required(ErrorMessage = " state es requerido")]
        public int state { get; set; }
    }

    public class UpdateClientDTOs
    {
         [Required(ErrorMessage = "Id es requerido")]
        public int Id { get; set; }

        [Required(ErrorMessage = "firstname es requerido")]
        [MaxLength(10)]
        public string firstname { get; set; }

        [Required(ErrorMessage = " surname es requerido")]
        [MaxLength(10)]
        public string surname { get; set; }

        [Required(ErrorMessage = "email es requerido")]
        [EmailAddress(ErrorMessage = "Formato invalido")]
        public string email { get; set; }

        [Required(ErrorMessage = " state es requerido")]
        public int state { get; set; }
    }

    public class FindClientOutputDTOs
    {
        public int Id { get; set; }

        public string firstname { get; set; }

        public string surname { get; set; }

        public string email { get; set; }

        public string state { get; set; }

    }
}