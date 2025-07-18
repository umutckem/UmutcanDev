using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmutcanDev.Application.Interfaces;
using UmutcanDev.Core.Model;
using UmutcanDev.Infrastructure.Data;

namespace UmutcanDev.Infrastructure.Services
{
    public class GeriBildirimServices : IGeriBildirimServices
    {
        private readonly ApplicationDbContext _context;

        public GeriBildirimServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Ekle(GeriBildirim geriBildirim)
        {
            _context.GeriBildirimler.Add(geriBildirim);
            await _context.SaveChangesAsync();
        }


        public Task<List<GeriBildirim>> geriBildirimsiGetir()
        {
            return _context.GeriBildirimler.ToListAsync();
        }

        public async Task Sil(int id)
        {
            var geriBildirim = await _context.GeriBildirimler.FindAsync(id);
            if (geriBildirim != null)
            {
                _context.GeriBildirimler.Remove(geriBildirim);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Geri bildirim bulunamadı.");
            }
        }
    }
}
