using ProductService.Entities;
using ProductService.Interfaces;

namespace ProductService.Business
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetProductById(string id)
        {
            return _productRepository.GetProductById(id);
        }

        //GetProductList
        public Product[] GetProductList()
        {
            return _productRepository.GetProductList();
        }
    }
}
