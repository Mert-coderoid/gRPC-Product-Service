using ProductService.Entities;

namespace ProductService.Interfaces
{
    public interface IProductService
    {
        Product GetProductById(string id);
        Product[] GetProductList();
    }
}
