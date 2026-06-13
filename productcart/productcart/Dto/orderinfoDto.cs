namespace productcart.Dto
{
    public class orderinfoDto
    {
        public string OrderId { get; set; }
        public int Status { get; set; }
        public float subtoatal { get; set; }
        public float Tax { get; set; }
        public float Total { get; set; }
        public string InvoiceId { get; set; }
    }

    public class allorderDto
    {
        
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Currency { get; set; }

        public List<orderinfoDto> orderinfoList { get; set; } = new List<orderinfoDto>();

    }
}
