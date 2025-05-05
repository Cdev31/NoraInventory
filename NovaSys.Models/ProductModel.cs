using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba_tec.NovaSys.Models
{
    [Table("product")]
    public class ProductModel
    {
     [Key]
     [Column("id")]
     public int Id { get; set; }

     public string name { get; set; }

     public decimal price { get; set; }

     public int stock { get; set;}

     public string state { get; set; }

     public string description { get; set; }
    }
}