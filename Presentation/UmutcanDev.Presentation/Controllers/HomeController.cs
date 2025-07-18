using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using UmutcanDev.Core.Model;
using UmutcanDev.Presentation.Models;
using UmutcanDev.Application.Interfaces;

namespace UmutcanDev.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISergiServices _sergiServices;

        public HomeController(ILogger<HomeController> logger, ISergiServices sergiServices)
        {
            _logger = logger;
            _sergiServices = sergiServices;
        }

        public async Task<IActionResult> Index()
        {
            var sergiler = await _sergiServices.GetSergis();

            // Null kontrolü ekleyebilirsin (opsiyonel)
            if (sergiler == null)
            {
                _logger.LogWarning("Sergi listesi boþ döndü.");
                return View(new List<Sergi>());
            }

            return View(sergiler);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
