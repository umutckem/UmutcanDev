using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmutcanDev.Core.Model;

namespace UmutcanDev.Application.Interfaces
{
    public interface IGeriBildirimServices
    {
        Task<List<GeriBildirim>> geriBildirimsiGetir();

        Task Ekle(GeriBildirim geriBildirim);
        Task Sil(int id);

    }
}
