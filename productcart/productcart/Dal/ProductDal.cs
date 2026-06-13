using Microsoft.EntityFrameworkCore.Storage.Json;
using productcart.Context;
using productcart.Dto;
using productcart.Entity;
using productcart.IDal;

namespace productcart.Dal
{
    public class ProductDal(productcontext _context) : IProductDal
    {
        public async Task CreateProduct(productDto productDto)
        {
            var product = new product
            {
                ProductName = productDto.ProductName,
                ProductPrice = productDto.ProductPrice,
            };

           _context.Product.Add(product);
           _context.SaveChanges(); 
           
        }

        public async Task DeleteProduct(int productId)
        {
            var product = _context.Product.Find(productId);

            if (product == null) {
                throw new Exception("Product not found for Delete");
            }
            _context.Product.Remove(product);
            _context.SaveChanges();
           
        }

        public async Task<productDto> FetchProductById(int productId)
        {
            var product = _context.Product.Find(productId);

            if (product == null)
            {
                throw new Exception("Product not found for Delete");
            }

            return new productDto
            {
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
            };

        }

        public async Task<bool> IsProductExist(int productId)
        {
           return _context.Product.Any(w=> w.Id == productId);
        }

        public async Task UpdateProduct(productDto productDto)
        {
            var product = _context.Product.Find(productDto.Id);

            if (product == null)
            {
                throw new Exception("Product not found for Delete");
            }

            product.ProductName = productDto.ProductName;
            product.ProductPrice = productDto.ProductPrice;
            _context.Product.Remove(product);
            _context.SaveChanges();
        }
    }
}
