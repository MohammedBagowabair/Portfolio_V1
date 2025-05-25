using CamLine.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CamLine.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private  ApplicationDbContext db;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DownloadFile()
        {
            var memory = DownloadSinghFile("Medical.pdf", "wwwroot\\MyFiles");
            return File(memory.ToArray(), "application/pdf", "Medical.pdf");
        }
        private MemoryStream DownloadSinghFile(string filename, string uploadPath)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), uploadPath, filename);
            var memory = new MemoryStream();
            if (System.IO.File.Exists(path))
            {
                var net = new System.Net.WebClient();
                var data = net.DownloadData(path);
                var content = new System.IO.MemoryStream(data);
                memory = content;
            }
            memory.Position = 0;
            return memory;
        }

        [HttpGet]
        public IActionResult Form()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Form(RegistraionForm registraionForm)
        {
            if (ModelState.IsValid)
            {
                db.Add(registraionForm);
                db.SaveChanges();
            }
            return RedirectToAction("RegistrationConfrmation");
        }

        [HttpGet]
        public IActionResult RegistrationConfrmation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegistrationConfrmation(string?d )
        {
           return RedirectToAction("DownloadFile");
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
