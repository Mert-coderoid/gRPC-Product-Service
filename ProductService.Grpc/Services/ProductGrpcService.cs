using ProductService.Interfaces;
using GrpcProductService;
using Grpc.Core;


namespace ProductService.Grpc.Services
{
    public class ProductGrpcService : ProductServiceGrpc.ProductServiceGrpcBase
    {
        private readonly IProductService _productService;

        public ProductGrpcService(IProductService productService)
        {
            _productService = productService;
        }

        public override Task<ProductResponse> GetProductInfo(ProductRequest request, ServerCallContext context)
        {
            var product = _productService.GetProductById(request.Id);

            var response = new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };

            return Task.FromResult(response);
        }

        public override async Task GetProductList(ProductRequest request, IServerStreamWriter<ProductResponse> responseStream, ServerCallContext context)
        {
            var products = _productService.GetProductList();

            foreach (var product in products)
            {
                var response = new ProductResponse
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price
                };

                await responseStream.WriteAsync(response);
            }
        }

        public override async Task<ProductResponse> GetProductListClientStream(IAsyncStreamReader<ProductRequest> requestStream, ServerCallContext context)
        {
            var productList = new List<ProductResponse>();

            await foreach (var request in requestStream.ReadAllAsync())
            {
                var product = _productService.GetProductById(request.Id);
                if (product != null)
                {
                    var response = new ProductResponse
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price
                    };

                    productList.Add(response);
                }

            }

            var totalPrice = productList.Sum(x => x.Price);
            var responseTotal = new ProductResponse
            {
                Id = "0",
                Name = "Toplam",
                Description = "Toplam",
                Price = totalPrice
            };

            return responseTotal;

        }

        public override async Task GetProductListBidirectionalStream(IAsyncStreamReader<ProductRequest> requestStream, IServerStreamWriter<ProductResponse> responseStream, ServerCallContext context)
        {
            //listen client messages 
            await foreach (var request in requestStream.ReadAllAsync())
            {
                var product = _productService.GetProductById(request.Id);

                if (product != null)
                {
                    //send messages for every product
                    await responseStream.WriteAsync(new ProductResponse
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price
                    });
                }
            }
        }
    }
}
