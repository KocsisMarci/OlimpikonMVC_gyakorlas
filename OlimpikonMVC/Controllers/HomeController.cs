using Microsoft.AspNetCore.Mvc;
using OlimpikonMVC.Models;
using System.Diagnostics;
using OlimpikonMVC.Services;
namespace OlimpikonMVC.Controllers
{
    public class HomeController : Controller
    {

        public static List<Orszag> orszagok = new OrszagService().Read();



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }



        public IActionResult Sajat(){

            orszagok = new OrszagService().Read();
            return View(orszagok);
        }


        public IActionResult Egyedi(int id) {
            //var adott = orszagok.FirstOrDefault(orszag => orszag.Id==id);

            Orszag orszag = new OrszagService().GetById(id); //Használjuk már ha elkészült.
            return View(orszag);
        }






        [HttpGet]

        public IActionResult CreateOrszag() {
            Orszag orszag = new Orszag();

            return View(orszag);
        }



        [HttpPost]

        public IActionResult CreateOrszag(Orszag orszag) {
            string eredmeny = new OrszagService().Insert(orszag);

            TempData["SuccessMessage"] = eredmeny;

            return RedirectToAction(nameof(CreateOrszag));
        }






        [HttpGet]

        public IActionResult UpdateOrszag() {
            Orszag orszag = new Orszag();

            return View(orszag);
        }


        [HttpPost]

        public IActionResult UpdateOrszag(Orszag orszag) {
            string eredmeny = new OrszagService().Update(orszag);

            TempData["Valami"] = eredmeny;

            return RedirectToAction(nameof(UpdateOrszag));
        }







        [HttpGet]
        public IActionResult DeleteOrszag() {
            Orszag orszag = new Orszag();

            return View(orszag);
        
        }



        [HttpPost]

        public IActionResult DeleteOrszag(int id)
        {
            TempData["SuccessMessage"] = new OrszagService().Delete(id);

            return RedirectToAction(nameof(DeleteOrszag));
        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
