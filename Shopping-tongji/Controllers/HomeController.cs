

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shopping_tongji.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
namespace Shopping_tongji.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public IActionResult Index(IFormCollection collection)
        {
            
            string userid = collection["userID"];
            string password = collection["password"];
            DataAccess.CreateConn();
            
            if (DataAccess.IsUserExist(userid, password))
            {
                Response.Redirect("Sign_In/Register");
                return Content("<script>alert('登录成功')</script>");
            }
            else
            {
                return Content("<script>alert('登录失败')</script>");
            }


        }
        [HttpPost]
        public IActionResult Register(IFormCollection collection)
        {
            return Content("登录成功");
        }
    }
}
