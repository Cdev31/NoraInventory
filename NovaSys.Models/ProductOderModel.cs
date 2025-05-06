using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba_tec.NovaSys.Models
{
    [Table("product_order")]
    public class ProductOrderModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("order_id")]
        public int order { get; set; }

        [ForeignKey("order")]
        public OrderModel orderId { get; set; }

        [Column("product_id")]
        public int product { get; set; }

        [ForeignKey("product")]
        public ProductModel productID { get; set; }
    }
}