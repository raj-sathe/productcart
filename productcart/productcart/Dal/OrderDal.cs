using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using productcart.Context;
using productcart.Dto;
using productcart.Entity;
using productcart.IDal;

namespace productcart.Dal
{
    public class OrderDal(productcontext _context) : IOrderDal
    {
        public async Task CancelOrder(int OrderId)
        {
            var order = _context.Order.Find(OrderId);

            if (order == null)
            {
                throw new Exception("order not found for cancel");
            }
            if (order.OrderStatus == 1)
            {
                order.OrderStatus = 0;
                _context.Order.Add(order);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("order not confirmed for cancel");
            }

        }

        public async Task<orderDto> CreateOrder(orderDto Orderdto)
        {
            var ordnum = _context.Order.OrderByDescending(w => w.Id).Select(w => w.OrderNumber).FirstOrDefault() + 1;
            var invnum = _context.Order.OrderByDescending(w => w.Id).Select(w => w.InvoiceNumber).FirstOrDefault() + 1;
            var data = new order
            {
                UserId = Orderdto.UserId,
                ProductId = Orderdto.ProductId,
                OrderStatus = Orderdto.OrderStatus,
                OrderSequence = $"ORD-{DateTime.Now.ToString("DDMMYYY")}-",
                OrderNumber = ordnum,
                InvoiceSequence = $"INV-{DateTime.Now.ToString("DDMMYYY")}-",
                InvoiceNumber = invnum,
                OrderPrice = Orderdto.OrderPrice,
                OrderTax = Orderdto.OrderPrice % 12,
            };
            _context.Add(data);
            _context.SaveChanges();
            Orderdto.OrderSequence = data.OrderSequence;
            Orderdto.OrderNumber = data.OrderNumber;
            Orderdto.InvoiceSequence = data.InvoiceSequence;
            Orderdto.InvoiceNumber = data.InvoiceNumber;
            Orderdto.OrderPrice = data.OrderPrice;
            Orderdto.OrderTax = data.OrderTax;

            return Orderdto;

        }

        public async Task<orderinfoDto> FetchOrderById(int OrderId)
        {
            var data = _context.Order.Where(w => w.Id == OrderId).FirstOrDefault();

            var orderinfo = new orderinfoDto
            {
                OrderId = data.OrderSequence + data.OrderNumber,
                Status = data.OrderStatus,
                Tax = data.OrderTax,
                subtoatal = data.OrderPrice,
                Total = data.OrderPrice + data.OrderTax,
                InvoiceId = data.InvoiceSequence + data.InvoiceNumber,
            };


            return orderinfo;
        }

        public async Task<orderinfoDto> FetchOrderByOrderNumber(string OrderNumber)
        {
            var data = _context.Order.Where(w => (w.OrderSequence+w.OrderNumber).Contains(OrderNumber,StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            var orderinfo = new orderinfoDto
            {
                OrderId = data.OrderSequence + data.OrderNumber,
                Status = data.OrderStatus,
                Tax = data.OrderTax,
                subtoatal = data.OrderPrice,
                Total = data.OrderPrice + data.OrderTax,
                InvoiceId = data.InvoiceSequence + data.InvoiceNumber,
            };


            return orderinfo;
        }

        public async Task<allorderDto> FetchAllOrderByUser(int userid)
        {
            var data = _context.Order.Where(w => w.UserId == userid).ToList();

            allorderDto allorderDto = new allorderDto();
            allorderDto.CustomerId = userid;
            allorderDto.CustomerName = _context.User.Where(w => w.Id == userid).Select(w=>w.UserName).FirstOrDefault()!;
            allorderDto.Currency = "INR";

            foreach (var order in data)
            {
                allorderDto.orderinfoList.Add(new orderinfoDto
                {
                    OrderId = order.OrderSequence + order.OrderNumber,
                    Status = order.OrderStatus,
                    Tax = order.OrderTax,
                    subtoatal = order.OrderPrice,
                    Total = order.OrderPrice + order.OrderTax,
                    InvoiceId = order.InvoiceSequence + order.InvoiceNumber,
                });
            }

            return allorderDto;
        }
    }
}
