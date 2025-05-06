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

        [Column("clinet_id")]
        public int client { get; set; }

        [ForeignKey("client")]
        public ClientModel clientId { get; set; }

        public int state { get; set; }

        [ForeignKey("state")]
        public StatesModel orderState { get; set; }

        public List<ProductOrderModel> Products { get; set; }
        
    }
}