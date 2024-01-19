
## Proje Özeti: gRPC Ürün Servisi

Bu projeyi geliştirirken ana amacım, gRPC teknolojisini kapsamlı bir şekilde kullanmak ve bu teknolojinin sağladığı avantajları derinlemesine keşfetmekti. İşte bu hedef doğrultusunda gerçekleştirdiğim temel işlemler:

### gRPC Servis Tanımları

-   **.proto Dosyası:** Ürün servisimin temel işlevlerini tanımladığım `.proto` dosyasını oluşturdum. Burada, gRPC'nin sağladığı veri yapıları ve servis tanımları üzerinde çalıştım.

### Unary RPC Implementasyonu

-   **Ürün Bilgisi Sorgulama:** Unary RPC modelini kullanarak, basit ve etkin bir istek-yanıt modeli uyguladım. Bu, gRPC'nin temel kullanım senaryolarından birini gösteriyor.

### Server Streaming RPC Implementasyonu

-   **Ürün Listesi Akışı:** Server streaming RPC ile sunucunun sürekli veri akışını nasıl sağlayabileceğini gösterdim. Bu, gRPC'nin streaming yeteneklerinin bir örneğiydi.

### Client Streaming RPC Implementasyonu

-   **İstemci Tarafından Akış:** İstemcinin birden fazla veri gönderdiği ve sunucunun bunu işlediği client streaming RPC modelini uyguladım. Bu, gRPC'nin daha karmaşık kullanım örneklerinden birini sergiliyor.

### Bidirectional Streaming RPC Implementasyonu

-   **Karşılıklı Veri Akışı:** İstemci ve sunucunun eş zamanlı olarak veri gönderip alabildiği bidirectional streaming modelini hayata geçirdim. Bu, gRPC'nin en esnek iletişim modellerinden biridir.

### İstemci Uygulaması

-   **gRPC İstemci:** Sunucu tarafındaki çeşitli gRPC servisleriyle etkileşim kuracak bir istemci uygulaması geliştirdim. Bu uygulama, gRPC'nin pratikte nasıl kullanılacağını gösteriyor.

Bu projenin temel amacı, gRPC teknolojisini uygulamalı bir şekilde incelemek ve bu modern RPC çerçevesinin sağladığı çeşitli iletişim modellerini deneyimlemekti. Projem, gRPC'nin güçlü ve esnek yapısını keşfetmek için güzel bir fırsat sundu.