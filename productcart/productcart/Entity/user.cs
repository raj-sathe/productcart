using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace productcart.Entity
{
    [Table("user")]
    public class user
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("username")]
        public string UserName { get; set; }
        [Column("mobilenumber")]
        public string MobileNumber { get; set; }
    }
}
