using productcart.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace productcart.Dto
{
    public class orderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int OrderStatus { get; set; }
        public int OrderNumber { get; set; }
        public string OrderSequence { get; set; }
        public int InvoiceNumber { get; set; }
        public string InvoiceSequence { get; set; }
        public float OrderPrice { get; set; }
        public float OrderTax { get; set; }
    }
}
