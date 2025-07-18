using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmutcanDev.Core.Model
{
    public class GeriBildirim
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string EMail { get; set; }
        public string Konu { get; set; }
        public string Mesaj { get; set; }

    }
}
