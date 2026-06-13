using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace productcart.Entity
{
    [Table("product")]
    public class product
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("productname")]
        public string ProductName { get; set; }
        [Column("productprice")]
        public float ProductPrice { get; set; }
    }
}
