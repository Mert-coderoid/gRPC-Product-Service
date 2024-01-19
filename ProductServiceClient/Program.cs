using Grpc.Core;
using Grpc.Net.Client;
using GrpcProductService;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serverAddress = "https://localhost:7020";
            using var channel = GrpcChannel.ForAddress(serverAddress);
            var client = new ProductServiceGrpc.ProductServiceGrpcClient(channel);

            while (true)
            {
                Console.WriteLine("1-Ürün bilgisini sorgula");
                Console.WriteLine("2-Ürün listesini sorgula (Server Stream)");
                Console.WriteLine("3-Ürün listesini sorgula (Client Stream)");
                Console.WriteLine("4-Ürün bilgisini güncelle (Bi-directional Stream)");
                Console.WriteLine("q-Çıkmak için 'q' tuşuna basın");
                Console.WriteLine("Seçiminiz: ");
                var selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        var requestInfo = new ProductRequest { Id = "1" };
                        try
                        {
                            var reply = await client.GetProductInfoAsync(requestInfo);
                            Console.WriteLine($"Ürün Adı: {reply.Name}");
                            Console.WriteLine($"Açıklama: {reply.Description}");
                            Console.WriteLine($"Fiyat: {reply.Price}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Bir hata oluştu: {e.Message}");
                        }
                        break;
                    case "2":
                        var requestList = new ProductRequest { Id = "2" };
                        try
                        {
                            var productList = client.GetProductList(requestList);
                            while (await productList.ResponseStream.MoveNext())
                            {
                                var product = productList.ResponseStream.Current;
                                Console.WriteLine($"Ürün Adı: {product.Name}");
                                Console.WriteLine($"Açıklama: {product.Description}");
                                Console.WriteLine($"Fiyat: {product.Price}");
                                Console.WriteLine("-------------------------------");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Bir hata oluştu: {e.Message}");
                        }
                        break;
                    case "3":
                        using (var call = client.GetProductListClientStream())
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                var request = new ProductRequest { Id = i.ToString() };
                                await call.RequestStream.WriteAsync(request);
                                }
                            await call.RequestStream.CompleteAsync();
                            var response = await call;
                            Console.WriteLine($"Ürün Adı: {response.Name}");
                            Console.WriteLine($"Açıklama: {response.Description}");
                            Console.WriteLine($"Fiyat: {response.Price}");
                            }
                        break;
                    case "4":
                        using (var call = client.GetProductListBidirectionalStream())
                        {
                            // Bidirectional streaming RPC
                            var sendTask = Task.Run(async () =>
                            {
                                for (int i = 0; i < 5; i++)
                                {
                                    var request = new ProductRequest { Id = i.ToString() };
                                    await call.RequestStream.WriteAsync(request);
                                    await Task.Delay(1000);
                                }
                                await call.RequestStream.CompleteAsync();
                                });
                            var responseTask = Task.Run(async () =>
                            {
                                await foreach (var response in call.ResponseStream.ReadAllAsync())
                                {
                                    Console.WriteLine($"Ürün Adı: {response.Name}");
                                    Console.WriteLine($"Açıklama: {response.Description}");
                                    Console.WriteLine($"Fiyat: {response.Price}");
                                    Console.WriteLine("-------------------------------");
                                }
                            });

                            await Task.WhenAll(sendTask, responseTask);
                            }
                        break;
                    case "q":
                        Console.WriteLine("Programdan çıkılıyor...");
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim!");
                        break;
                }
            }
        }
    }
}
