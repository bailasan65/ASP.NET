using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResturantDelivery.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace ResturantDelivery.Controllers
{
    public class MenuController : Controller
    {
        private ResturentDeliveryContext context;
        public MenuController(ResturentDeliveryContext mtx)
        {
            context = mtx;
        }
        public IActionResult Index()
        {
            var Menu = context.Menus.ToList();
            return View(Menu);
        }
        public IActionResult search(string searchkey)

        {

            var menu = context.Menus.Where(m => m.name.Contains(searchkey)).ToList();
            return View("Index", menu);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.menu = context.Menus.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Menu mm)
        {
            context.Menus.Add(mm);
            context.SaveChanges();
            return RedirectToAction("Index", "Menu");
        }

      

    }
}


