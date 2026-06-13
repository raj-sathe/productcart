using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Azure.Core.Pipeline;
using Microsoft.EntityFrameworkCore;

namespace productcart.Entity
{
    [Table("order")]
    public class order
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("userid")]
        public int UserId { get; set; }
        public virtual user user { get; set; }
        [Column("productid")]
        public int ProductId { get; set; }
        public virtual product product { get; set; }
        [Column("orderstatus")]
        public int OrderStatus { get; set; }
        [Column("ordernumber")]
        public int OrderNumber { get; set; }
        [Column("ordersequence")]
        public string OrderSequence { get; set; }
        [Column("invoicenumber")]
        public int InvoiceNumber { get; set; }
        [Column("invoicesequence")]
        public string InvoiceSequence { get; set; }
        [Column("orderprice")]
        public float OrderPrice { get; set; }
        [Column("ordertax")]
        public float OrderTax { get; set; }

    }
}

