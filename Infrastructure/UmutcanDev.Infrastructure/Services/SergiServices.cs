using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UmutcanDev.Application.Interfaces;
using UmutcanDev.Core.Model;
using UmutcanDev.Infrastructure.Data;

namespace UmutcanDev.Infrastructure.Services
{
    public class SergiServices : ISergiServices
    {
        private readonly ApplicationDbContext _context;

        public SergiServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Sergi>> GetSergis()
        {
            return await _context.Sergis  // DbSet ismi büyük harf ile olmalı
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task SergiEkle(Sergi sergi)
        {
            if (sergi == null)
                throw new ArgumentNullException(nameof(sergi));

            await _context.Sergis.AddAsync(sergi);
            await _context.SaveChangesAsync();
        }

        public async Task SergiGuncelle(Sergi sergi)
        {
            if (sergi == null)
                throw new ArgumentNullException(nameof(sergi));

            var existing = await _context.Sergis.FindAsync(sergi.Id);
            if (existing == null)
                throw new KeyNotFoundException("Sergi bulunamadı.");

            existing.ProjeAdi = sergi.ProjeAdi;
            existing.Aciklama = sergi.Aciklama;
            existing.GithubUrl = sergi.GithubUrl;
            existing.ResimUrl = sergi.ResimUrl;
            existing.Teknolojiler = sergi.Teknolojiler;
            existing.OlusturmaTarihi = sergi.OlusturmaTarihi;
            existing.Durum = sergi.Durum;

            await _context.SaveChangesAsync();
        }

        public async Task SergiSil(int id)
        {
            var sergi = await _context.Sergis.FindAsync(id);
            if (sergi == null)
                throw new KeyNotFoundException("Sergi bulunamadı.");

            _context.Sergis.Remove(sergi);
            await _context.SaveChangesAsync();
        }
    }
}
