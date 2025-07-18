using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using UmutcanDev.Application.Interfaces;

namespace UmutcanDev.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class GeriBildirimController : Controller
    {
        private readonly IGeriBildirimServices _geriBildirimServices;

        public GeriBildirimController(IGeriBildirimServices geriBildirimServices)
        {
            _geriBildirimServices = geriBildirimServices;
        }

        // Listeleme ve arama
        public async Task<IActionResult> Index(string search)
        {
            var geriBildirimler = await _geriBildirimServices.geriBildirimsiGetir();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                geriBildirimler = geriBildirimler
                    .Where(g => (g.AdSoyad ?? "").ToLower().Contains(search)
                             || (g.EMail ?? "").ToLower().Contains(search)
                             || (g.Konu ?? "").ToLower().Contains(search)
                             || (g.Mesaj ?? "").ToLower().Contains(search))
                    .ToList();
            }

            ViewData["Search"] = search ?? "";

            return View(geriBildirimler);
        }


        // Silme işlemi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Sil(int id)
        {
            await _geriBildirimServices.Sil(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
