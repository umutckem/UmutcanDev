# UmutcanDev - Kişisel Portföy Projesi

Bu proje, Umutcan Kemahlı'nın kişisel portföy web sitesidir. ASP.NET Core MVC mimarisi kullanılarak geliştirilmiş modern ve responsive bir web uygulamasıdır.

## 🚀 Özellikler

- **Modern UI/UX**: Bootstrap 5 ve özel CSS ile tasarlanmış responsive arayüz
- **Dark/Light Mode**: Kullanıcı tercihine göre tema değiştirme
- **Animasyonlar**: AOS (Animate On Scroll) ve Particles.js ile etkileyici animasyonlar
- **Proje Sergisi**: Dinamik proje kartları ve filtreleme sistemi
- **İletişim Formu**: Geri bildirim alma sistemi
- **Admin Paneli**: Proje ve geri bildirim yönetimi
- **Email Sistemi**: Otomatik email gönderimi
- **Responsive Tasarım**: Tüm cihazlarda mükemmel görünüm

## 🏗️ Proje Yapısı

```
UmutcanDev/
├── Application/                 # Uygulama Katmanı
│   └── UmutcanDev.Application/
│       └── Interfaces/         # Servis arayüzleri
├── Core/                       # Çekirdek Katman
│   └── UmutcanDev.Core/
│       └── Model/             # Veri modelleri
├── Infrastructure/             # Altyapı Katmanı
│   └── UmutcanDev.Infrastructure/
│       ├── Data/              # Veritabanı context
│       ├── Migrations/        # Entity Framework migrations
│       └── Services/          # Servis implementasyonları
└── Presentation/              # Sunum Katmanı
    └── UmutcanDev.Presentation/
        ├── Areas/             # Alan bazlı routing
        │   ├── Admin/         # Admin paneli
        │   └── Identity/      # Kimlik doğrulama
        ├── Controllers/       # MVC Controller'ları
        ├── Views/            # Razor view'ları
        └── wwwroot/          # Statik dosyalar
```

## 🛠️ Teknolojiler

### Backend
- **ASP.NET Core 9.0** - Web framework
- **Entity Framework Core** - ORM
- **SQL Server** - Veritabanı
- **Identity Framework** - Kimlik doğrulama
- **Dependency Injection** - IoC container

### Frontend
- **Bootstrap 5** - CSS framework
- **jQuery** - JavaScript kütüphanesi
- **AOS (Animate On Scroll)** - Scroll animasyonları
- **Particles.js** - Arka plan animasyonları
- **Bootstrap Icons** - İkon kütüphanesi

### Mimari
- **Clean Architecture** - Temiz mimari prensipleri
- **Repository Pattern** - Veri erişim deseni
- **Service Layer** - İş mantığı katmanı
- **Area-based Routing** - Alan bazlı yönlendirme

## 📋 Gereksinimler

- .NET 9.0 SDK
- SQL Server (LocalDB veya SQL Server Express)
- Visual Studio 2022 veya VS Code

## 🚀 Kurulum

1. **Projeyi klonlayın**
   ```bash
   git clone https://github.com/umutckem/UmutcanDev.git
   cd UmutcanDev
   ```

2. **Veritabanını oluşturun**
   ```bash
   cd Presentation/UmutcanDev.Presentation
   dotnet ef database update
   ```

3. **Uygulamayı çalıştırın**
   ```bash
   dotnet run
   ```

4. **Tarayıcıda açın**
   ```
   https://localhost:7000
   ```

## ⚙️ Yapılandırma

### Veritabanı Bağlantısı
`appsettings.json` dosyasında connection string'i yapılandırın:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=UmutcanDev;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

### Email Ayarları
Email gönderimi için SMTP ayarlarını yapılandırın:

```json
{
  "EmailSettings": {
    "SmtpServer": "smtp.gmail.com",
    "Port": 587,
    "Username": "your-email@gmail.com",
    "Password": "your-app-password",
    "EnableSsl": true
  }
}
```

## 📱 Kullanım

### Ana Sayfa
- Hero section ile kişisel tanıtım
- Hakkımda bölümü
- Yetenekler ve teknolojiler
- Proje sergisi
- İletişim formu

### Admin Paneli
- `/Admin` URL'si ile erişim
- Proje ekleme/düzenleme/silme
- Geri bildirim yönetimi
- Kullanıcı yönetimi

### Proje Yönetimi
- Proje adı, açıklama, teknolojiler
- GitHub linki ve resim URL'si
- Oluşturma tarihi ve durum bilgisi

## 🎨 Özelleştirme

### Tema Değişiklikleri
- `wwwroot/css/site.css` - Ana stil dosyası
- `wwwroot/css/portfolio.css` - Portföy özel stilleri
- Dark/Light mode için CSS değişkenleri

### Animasyonlar
- `Views/Shared/_Layout.cshtml` - Particles.js konfigürasyonu
- `Views/Home/Index.cshtml` - AOS animasyonları

### İçerik Güncelleme
- Proje bilgileri: Admin panelinden
- Kişisel bilgiler: View dosyalarından
- Sosyal medya linkleri: `Index.cshtml` dosyasından

## 🔧 Geliştirme

### Yeni Özellik Ekleme
1. Core katmanında model oluşturun
2. Application katmanında interface tanımlayın
3. Infrastructure katmanında servis implementasyonu yapın
4. Presentation katmanında controller ve view ekleyin

### Veritabanı Değişiklikleri
```bash
# Yeni migration oluştur
dotnet ef migrations add MigrationName

# Veritabanını güncelle
dotnet ef database update
```

## 📊 Proje Modelleri

### Sergi (Proje) Modeli
```csharp
public class Sergi
{
    public int Id { get; set; }
    public string ProjeAdi { get; set; }
    public string Aciklama { get; set; }
    public string GithubUrl { get; set; }
    public string? ResimUrl { get; set; }
    public string Teknolojiler { get; set; }
    public DateTime? OlusturmaTarihi { get; set; }
    public string? Durum { get; set; }
}
```

### Geri Bildirim Modeli
```csharp
public class GeriBildirim
{
    public int Id { get; set; }
    public string AdSoyad { get; set; }
    public string EMail { get; set; }
    public string Konu { get; set; }
    public string Mesaj { get; set; }
}
```

## 🌟 Öne Çıkan Özellikler

- **Responsive Tasarım**: Mobil uyumlu modern arayüz
- **Performans**: Optimize edilmiş yükleme süreleri
- **SEO Dostu**: Meta tag'ler ve semantic HTML
- **Erişilebilirlik**: WCAG standartlarına uygun
- **Güvenlik**: Identity framework ile güvenli kimlik doğrulama

## 📞 İletişim

- **Email**: umutcankemahli637@gmail.com
- **LinkedIn**: [Umutcan Kemahlı](https://www.linkedin.com/in/umutcan-kemahl%C4%B1-0ab41a31a/)
- **GitHub**: [umutckem](https://github.com/umutckem)
- **Instagram**: [umutcan_kemahli](https://www.instagram.com/umutcan_kemahli/)

## 📄 Lisans

Bu proje MIT lisansı altında lisanslanmıştır.

## 🤝 Katkıda Bulunma

1. Fork yapın
2. Feature branch oluşturun (`git checkout -b feature/AmazingFeature`)
3. Değişikliklerinizi commit edin (`git commit -m 'Add some AmazingFeature'`)
4. Branch'inizi push edin (`git push origin feature/AmazingFeature`)
5. Pull Request oluşturun

---

**Umutcan Kemahlı** - Bilgisayar Mühendisi Öğrencisi  
*Hayallerini satır satır kodlayan bir öğrenci* 🚀
