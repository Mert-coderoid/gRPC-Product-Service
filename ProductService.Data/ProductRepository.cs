using ProductService.Entities;
using ProductService.Interfaces;

namespace ProductService.Data
{
    public class ProductRepository : IProductRepository
    {
        public Product GetProductById(string id)
        {
            return new Product
            {
                Id = id,
                Name = "Örnek Ürün",
                Description = "Bu bir örnek üründür.",
                Price = 99.99f
            };
        }

        public Product[] GetProductList()
        {
            return new Product[]
            {
                new Product
                {
                    Id = "1",
                    Name = "Örnek Ürün 1",
                    Description = "Bu bir örnek üründür.",
                    Price = 19.99f
                },
                new Product
                {
                    Id = "2",
                    Name = "Örnek Ürün 2",
                    Description = "Bu bir örnek üründür.",
                    Price = 29.99f
                },
                new Product
                {
                    Id = "3",
                    Name = "Örnek Ürün 3",
                    Description = "Bu bir örnek üründür.",
                    Price = 39.99f
                },
                new Product
                {
                    Id = "4",
                    Name = "Örnek Ürün 4",
                    Description = "Bu bir örnek üründür.",
                    Price = 49.99f
                },
                new Product
                {
                    Id = "5",
                    Name = "Örnek Ürün 5",
                    Description = "Bu bir örnek üründür.",
                    Price = 59.99f
                }
            };
        }
    }
}
