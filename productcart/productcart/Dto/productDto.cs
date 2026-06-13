using System.ComponentModel.DataAnnotations.Schema;

namespace productcart.Dto
{
    public class productDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }
    }
}
