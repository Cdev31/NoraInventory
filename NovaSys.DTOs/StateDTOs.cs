using System.ComponentModel.DataAnnotations;

namespace prueba_tec.NovaSys.DTOs
{
    public class CreateStateDTOs
    {
        [Required(ErrorMessage = "stateName es requerido ")]
        [MaxLength(20)]
        public string stateName { get; set; }

        [Required(ErrorMessage = "moduleName es requerido ")]
        [MaxLength(20)]
        public string moduleName { get; set; }
    }

    public class UpdateStateDTOs
    {
        [Required(ErrorMessage = "stateName es requerido ")]
        [MaxLength(20)]
        public string stateName { get; set; }

        [Required(ErrorMessage = "moduleName es requerido ")]
        [MaxLength(20)]
        public string moduleName { get; set; }
    }

    public class FindStatesOutputDTOs
    {
        public int Id { get; set; }

        public string stateName { get; set; }

        public string moduleName { get; set; }
    }
}