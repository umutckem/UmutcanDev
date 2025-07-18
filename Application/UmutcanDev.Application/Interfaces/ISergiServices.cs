using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmutcanDev.Core.Model;

namespace UmutcanDev.Application.Interfaces
{
    public interface ISergiServices
    {
        Task<List<Sergi>> GetSergis();

        Task SergiEkle(Sergi sergi);

        Task SergiGuncelle(Sergi sergi);

        Task SergiSil(int id);

    }
}
