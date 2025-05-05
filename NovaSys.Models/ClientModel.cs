using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba_tec.NovaSys.Models
{
    [Table("client")]
    public class ClientModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        public string firstname { get; set; }

        public string surname { get; set; }

        public string email { get; set; }

        public string state { get; set; }

    }
}