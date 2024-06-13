using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Trac_WorkReport.Models;

namespace Trac_WorkReport.Controllers
{
    public class MapController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Map()
        {
            ViewData["Message"] = "Your OpenLayers map page.";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
