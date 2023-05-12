using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResturantDelivery.Models;
using System.Collections.Generic;
using System.Linq;

namespace ResturantDelivery.Controllers
{
    public class CustomerController : Controller
        
    {
        private ResturentDeliveryContext context;
        public CustomerController(ResturentDeliveryContext ctx)
        {
             context=ctx;
        }
        public IActionResult Index()
        {
           var customer= context.customerss.ToList();
            return View(customer);  
        }


        public IActionResult Add()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Add(Customer cc)
        {
            context.customerss.Add(cc);
            context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetInt32("usid") == null)
                return View();

            return RedirectToAction("Index","Menu");
        }
        public IActionResult Login (string csid ,string cspass)
        {
            Customer c = context.customerss.Where(S => S.name == csid && S.password == cspass).FirstOrDefault();
            if (c != null) 
            {
                HttpContext.Session.SetInt32("usid",c.customerid);
                HttpContext.Session.SetString("cstatus",c.status);

                return RedirectToAction("Index", "Menu");
            }
            
            return View();
            
        }
        public IActionResult De()
           
        {
            if (HttpContext.Session.GetInt32("usid") == null)
                return RedirectToAction("Login");
            else
            {
                int? custid = HttpContext.Session.GetInt32("usid");


                Customer cu = context.customerss.Where(s=>s.customerid==custid).FirstOrDefault();
                return View(cu);
            }
        }
        [HttpGet]
        public IActionResult ChangPassword() {
            if (HttpContext.Session.GetInt32("usid") == null)
                return RedirectToAction("Login");
                return View();

        }
        [HttpPost]
        public IActionResult ChangPassword( string newPass)
        {
            if (HttpContext.Session.GetInt32("usid") == null)   
                return RedirectToAction("Login");
            int? custid = HttpContext.Session.GetInt32("usid");
            Customer cu = context.customerss.Find(custid);
            cu.password = newPass;
            context.customerss.Update(cu);
            context.SaveChanges();
            return RedirectToAction("Index", "Menu"); ;

        }
        public IActionResult Logout() {
            HttpContext.Session.Clear();
            return View("Login");
        }    

    }
}
