using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanlaptop.Models;
namespace WebBanlaptop.Controllers
{
    public class UserController : Controller
    {
        private static string urlAfterLogin; // lưu lại link đang ở trước khi nhấn đăng nhập


        QLBANLAPTOPEntities db = new QLBANLAPTOPEntities();

        #region đăng nhập
        [HttpGet]
        public ActionResult Login(string strURL)
        {
            // kiểm tra đường dẫn có null không, tránh tình trạng paste trực tiếp đường link vào url sẽ không lưu được trả về trang chủ
            if (!String.IsNullOrEmpty(strURL))
            {
                urlAfterLogin = strURL;
            }
            else
            {
                RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var username = collection["username"];
            var password = collection["password"];
            var user = db.KHACHHANG.SingleOrDefault(p => p.USERNAME == username);
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                ViewData["Error"] = "Vui lòng điền đầy đủ nội dung";
                return this.Login(urlAfterLogin);
            }
            else if (user == null)
            {
                ViewData["Error"] = "invalid username";
                return this.Login(urlAfterLogin);
            }
            else if (!String.Equals(password, user.PASSWORD))
            {
                ViewData["Error"] = "invalid password";
                return this.Login(urlAfterLogin);
            }
            else
            {
                Session["User"] = user;
                return Redirect(urlAfterLogin);
            }
        }
        #endregion
        #region đăng xuất
        public ActionResult LogOut() // đăng xuất
        {
            Session["User"] = null;
            urlAfterLogin = null;
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}