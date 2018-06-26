using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop3.DAL.Abstract;
using WebShop3.DAL.Concrete;
using WebShop3.DAL.Entities;
using WebShop3.Models;

namespace WebShop3.Controllers
{
    public class UserController : Controller
    {
        private IUserProvider _userProvider;
        public UserController(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterUserViewModel user)
        {
            var el = _userProvider.RegisterUser(user);
            if(el==null)
            {
                ModelState.AddModelError("","Email is already taken");
                return View();
            }
            return View("UserSuccess");
        }
    }
}