using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShop3.Controllers
{
    public class AdministratorController : Controller
    {
        // GET: Administrator
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
    }
}