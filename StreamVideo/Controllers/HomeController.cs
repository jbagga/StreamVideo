using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StreamVideo.Models;
using System.IO;
using Microsoft.AspNetCore.StaticFiles;

namespace StreamVideo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Stream()
        {
            new FileExtensionContentTypeProvider().TryGetContentType("test.mp4", out string contentType);
            FileStream file = new FileStream("video.mp4", FileMode.Open, FileAccess.Read, FileShare.Read, 8 * 1024 * 1024);
            return new FileStreamResult(file, "video/mp4");
        }
    }
}
