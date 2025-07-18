using System;
using System.Collections.Generic;

namespace UmutcanDev.Core.Model
{
    public class Sergi
    {
        public int Id { get; set; }

        public string ProjeAdi { get; set; } = string.Empty;

        public string Aciklama { get; set; } = string.Empty;

        public string GithubUrl { get; set; } = string.Empty;

        public string? ResimUrl { get; set; }

        // ❗ Bu alan EF Core ile doğrudan desteklenmediği için özel işlem gerekir.
        // Bu yüzden alternatif string olarak tutulur ve View'da string[]'e ayrılır.
        public string Teknolojiler { get; set; } = string.Empty; // Örn: "C#, ASP.NET, SQL"

        public DateTime? OlusturmaTarihi { get; set; }

        public string? Durum { get; set; }

        // View'da kullanım için hazır dizi
        public List<string> TeknolojilerListesi =>
            string.IsNullOrWhiteSpace(Teknolojiler)
            ? new List<string>()
            : Teknolojiler.Split(',', StringSplitOptions.TrimEntries).ToList();
    }
}
