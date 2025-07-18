using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UmutcanDev.Application.Interfaces;
using UmutcanDev.Core.Model;

namespace UmutcanDev.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SergiController : Controller
    {
        private readonly ISergiServices _sergiServices;

        public SergiController(ISergiServices sergiServices)
        {
            _sergiServices = sergiServices;
        }

        public async Task<IActionResult> Index()
        {
            var sergiler = await _sergiServices.GetSergis();
            return View(sergiler);
        }

        [HttpGet]
        public IActionResult SergiEkle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SergiEkle(Sergi sergi)
        {
            if (!ModelState.IsValid)
                return View(sergi);

            sergi.OlusturmaTarihi = DateTime.Now;
            await _sergiServices.SergiEkle(sergi);

            return RedirectToAction("Index", "AdminPanel", new { area = "Admin" });
        }

        // Silme işlemi
        [HttpGet]
        public async Task<IActionResult> Sil(int id)
        {
            await _sergiServices.SergiSil(id);
            return RedirectToAction("Index");
        }

        // Düzenleme GET
        [HttpGet]
        public async Task<IActionResult> Duzenle(int id)
        {
            var sergiler = await _sergiServices.GetSergis();
            var sergi = sergiler.FirstOrDefault(s => s.Id == id);
            if (sergi == null)
            {
                return NotFound();
            }
            return View(sergi);
        }

        // Düzenleme POST
        [HttpPost]
        public async Task<IActionResult> Duzenle(Sergi sergi)
        {
            if (!ModelState.IsValid)
            {
                return View(sergi);
            }

            await _sergiServices.SergiGuncelle(sergi);
            return RedirectToAction("Index");
        }
    }
}
