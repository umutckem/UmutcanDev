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

        public string Teknolojiler { get; set; } = string.Empty; 

        public DateTime? OlusturmaTarihi { get; set; }

        public string? Durum { get; set; }

        public List<string> TeknolojilerListesi =>
            string.IsNullOrWhiteSpace(Teknolojiler)
            ? new List<string>()
            : Teknolojiler.Split(',', StringSplitOptions.TrimEntries).ToList();
    }
}
