using ProductService.Entities;

namespace ProductService.Interfaces
{
    public interface IProductRepository
    {
        Product GetProductById(string id);
        Product[] GetProductList();
    }
}
