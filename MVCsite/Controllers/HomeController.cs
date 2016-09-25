using CourseProject.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCsite.Controllers
{
    [RequireHttps]
    [Culture]
    public class HomeController : DefaultController
    {
        
        public ActionResult Index()
        {
            return View();
        }
    }
}