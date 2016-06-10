using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestNet.Web.Mvc5.Models;

namespace TestNet.Web.Mvc5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [Route("Jobs/{id}")]
        public ActionResult Jobs(long id)
        {            
            return View();
        }

        [Authorize]
        [Route("users")]
        public JsonResult Users()
        {
            return Json(_db.Users.Select(x => new { id = x.Id, email = x.Email }), JsonRequestBehavior.AllowGet);
        }
        
    }
}