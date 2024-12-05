using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using moi.Models;
using moi.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace moi.Controllers
{
    [Authorize]
    public class ReviewController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Review
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult _Review(int productId)
        {
            ViewBag.ProductId = productId; 
            var item = new ReviewProduct();
            if(User.Identity.IsAuthenticated)
            {
                var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = userManager.FindByName(User.Identity.Name);
                if(user != null) 
                {
                    item.Email = user.Email;
                    item.FullName = user.FullName;
                    item.UserName = user.UserName;
                }
                return PartialView(item);
            }
            return PartialView();
        }
        public ActionResult LichSuDonhang()
        {
            if(User.Identity.IsAuthenticated)
            {
                var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = userManager.FindByName(User.Identity.Name);
                var items = _db.Orders.Where(x=>x.CustomerId == user.Id).OrderByDescending(x=>x.CreatedDate).ToList();
                return View(items);
            }
            return View();
        }
        public ActionResult _load_Anh(int id)
        {
            var item = _db.OrderDetails.Where(x => x.OrderId == id).OrderByDescending(x => x.Id).ToList();
            return PartialView(item);
        }
        [AllowAnonymous]
        public ActionResult _load_Review(int productId)
        {
            var item = _db.Review.Where(x => x.ProductId == productId).OrderByDescending(x => x.Id).ToList();
            ViewBag.Count = item.Count;
            return PartialView(item);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult PostReview(ReviewProduct req)
        {
            if(ModelState.IsValid)
            {
                req.CreatedDate = DateTime.Now;
                _db.Review.Add(req);
                _db.SaveChanges();
                return Json(new { Success = true });
            }    
            return Json(new { Success = false});
        }
        public ActionResult View(int id)
        {
            var items = _db.OrderDetails.Where(x => x.OrderId == id).ToList();
            return View(items);
        }
        [HttpPost]
        public ActionResult Cancel(int orderId)
        {
            // Ở đây bạn thực hiện việc cập nhật trạng thái đơn hàng trong cơ sở dữ liệu.
            // Đây chỉ là một ví dụ đơn giản, bạn cần thay thế nó bằng logic xác định của mình.
            var order = _db.Orders.FirstOrDefault(o => o.Id == orderId);
            if (order != null)
            {
                order.OrderTT = "Đã huỷ hàng";
                _db.SaveChanges();
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, errorMessage = "Đơn hàng không tồn tại." });
            }
        }
    }
}