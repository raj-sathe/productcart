using System.ComponentModel.DataAnnotations.Schema;

namespace productcart.Dto
{
    public class userDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string MobileNumber { get; set; }
    }
}
