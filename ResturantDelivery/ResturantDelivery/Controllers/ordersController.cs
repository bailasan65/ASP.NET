using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using ResturantDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ResturantDelivery.Controllers
{
    public class ordersController : Controller
    {

        private ResturentDeliveryContext context;
        public ordersController(ResturentDeliveryContext con)
        {
            context = con;

        }
        public IActionResult Index()
        {
            List<orders> orders= context.orderss.Include(m => m.Customer).Include(s=>s.Menu).ToList();
            return View(orders);
        }
        public IActionResult search(int searchkey)

        {

            var menu = context.orderss.Where(m =>m.customerid.Equals(searchkey)).Include(m => m.Customer).Include(b=>b.Menu).ToList();
            return View("Index",menu);
             
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.customers=context.customerss.OrderBy(c=>c.name).ToList();    
            return View();
        }
        [HttpPost]
        public IActionResult Add(orders mm)
        {
            context.orderss.Add(mm);
            context.SaveChanges();  
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int  id )
        {
orders mm= context.orderss.Where(m=>m.id==id).FirstOrDefault();
            context.Remove(mm);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
      
    } }
    
