using App.Repositories.Products;

namespace App.Services.Products
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        public async Task<ServiceResult<List<Product>>> GetTopPriceProductsAsync(int count)
        {
            var products = await productRepository.GetTopPriceProductsAsync(count);
            return new ServiceResult<List<Product>>
            {
                Data = products
            };
        }

        public async Task<ServiceResult<Product>> GetProductByIdAsync(int id)
        {
            var product = await productRepository.GetByIdAsync(id);

            if (product is null)
            {
                return new ServiceResult<Product>
                {
                    ErrorMessage = new List<string>() { "Product not found." }
                };
            }

            return new ServiceResult<Product>
            {
                Data = product
            };
        }
    }
}
