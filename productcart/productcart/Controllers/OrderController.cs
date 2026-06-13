using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using productcart.Dal;
using productcart.Dto;
using productcart.IDal;

namespace productcart.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController(IOrderDal _orderdal) : ControllerBase
    {

        [HttpPost]
        public IActionResult CreateOrder(orderDto orderDto)
        {
            var order = _orderdal.CreateOrder(orderDto);
            return Ok("Order Is Created");
        }

        [HttpGet]
        public IActionResult FetchAllOrderByUser(int userId)
        {
            var data = _orderdal.FetchAllOrderByUser(userId);
            return Ok(data);
        }

        [HttpGet]
        public IActionResult FetchOrderByOrderNumber(string ordernumber)
        {
            var data = _orderdal.FetchOrderByOrderNumber(ordernumber);
            return Ok(data);
        }

        [HttpGet]
        public IActionResult CancelOrder(int orderid)
        {
            var data = _orderdal.CancelOrder(orderid);
            return Ok(data);
        }
    }
}
