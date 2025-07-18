using Microsoft.AspNetCore.Mvc;
using UmutcanDev.Application.Interfaces;
using UmutcanDev.Core.Model;

namespace UmutcanDev.Presentation.Controllers
{
    public class GeriBildirimController : Controller
    {
        private readonly IGeriBildirimServices _geriBildirimServices;

        public GeriBildirimController(IGeriBildirimServices geriBildirimServices)
        {
            _geriBildirimServices = geriBildirimServices;
        }

        [HttpPost]
        public async Task<IActionResult> GeriBildirimEkle(GeriBildirim geriBildirim)
        {
            if (ModelState.IsValid)
            {
                await _geriBildirimServices.Ekle(geriBildirim);
                TempData["Message"] = "Geri bildiriminiz başarıyla alındı.";
                return RedirectToAction("Index", "Home");
            }

            // Model geçersizse formu geri döndür
            return RedirectToAction("Index", "Home");
        }

    }
}
