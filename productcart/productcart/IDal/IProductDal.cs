using productcart.Dto;

namespace productcart.IDal
{
    public interface IProductDal
    {
        public Task CreateProduct(productDto productDto);
        public Task UpdateProduct(productDto productDto);
        public Task DeleteProduct(int productId);
        public Task<productDto> FetchProductById(int productId);
        public Task<bool> IsProductExist(int productId);
    }
}
