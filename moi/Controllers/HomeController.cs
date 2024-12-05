using moi.Models;
using moi.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace moi.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            ViewBag.Title = "DUCANH Shop";
            ViewBag.SeoDescription = "DUCANH Shop";
            return View();
        }

        public ActionResult Partial_Subcice()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Subcribe(Subscribe req)
        {
            if(ModelState.IsValid)
            {
                db.Subscribes.Add(new Subscribe { Email = req.Email, CreatedDate = DateTime.Now });
                db.SaveChanges();
                return Json(new {Success = true});
            }    
            return View("Partial_Subcice",req);
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Refresh()
        {
            var item = new ThongKeModel();
            ViewBag.Visitors_online = HttpContext.Application["visitors_online"];
            var hn = HttpContext.Application["HomNay"];
            item.HomNay = HttpContext.Application["HomNay"].ToString();
            item.HomQua = HttpContext.Application["HomQua"].ToString();
            item.TuanNay = HttpContext.Application["TuanNay"].ToString();
            item.TuanTruoc = HttpContext.Application["TuanTruoc"].ToString();
            item.ThangNay = HttpContext.Application["ThangNay"].ToString();
            item.ThangTruoc = HttpContext.Application["ThangTruoc"].ToString();
            item.TatCa = HttpContext.Application["TatCa"].ToString();
            return PartialView(item);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Customer()
        {
            var items = db.Customers.ToList();
            return PartialView("_chamsockhachhang", items);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            // Thêm khách hàng mới vào danh sách

            db.Customers.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}