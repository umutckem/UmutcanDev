using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UmutcanDev.Core.Model;

namespace UmutcanDev.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Sergi> Sergis { get; set; }
        public DbSet<GeriBildirim> GeriBildirimler { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
