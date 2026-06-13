using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using productcart.Dto;
using productcart.IDal;

namespace productcart.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class productController(IProductDal _productdal) : ControllerBase
    {

        [HttpPost]
        public IActionResult CreateProduct(productDto productDto)
        {
            var user = _productdal.CreateProduct(productDto);
            return Ok("product Is Created");
        }

        [HttpPut]
        public IActionResult UpdateProduct(productDto productDto)
        {
            var user = _productdal.UpdateProduct(productDto);
            return Ok("product Is Updated");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int productId)
        {
            var user = _productdal.DeleteProduct(productId);
            return Ok("product Is Deleted");
        }

        [HttpGet]
        public IActionResult FetchProductById(int productId)
        {
            var product = _productdal.FetchProductById(productId);
            return Ok(product);
        }
    }
}
