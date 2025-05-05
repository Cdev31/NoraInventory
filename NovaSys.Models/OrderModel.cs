using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba_tec.NovaSys.Models
{
    [Table("orders")]
    public class OrderModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        public DateTime created { get; set; }

        public string state { get; set; }

        [Column("clinet_id")]
        public int client { get; set; }

        [ForeignKey("client")]
        public ClientModel clientId { get; set; }
        
    }
}