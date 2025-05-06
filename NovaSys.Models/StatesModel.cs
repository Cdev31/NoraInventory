using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba_tec.NovaSys.Models
{
    [Table("states")]
    public class StatesModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("state_name")]
        public string stateName { get; set; }

        [Column("module_name")]
        public string moduleName { get; set; }
        
    }
}