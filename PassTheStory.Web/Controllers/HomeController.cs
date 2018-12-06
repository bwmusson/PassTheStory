using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PassTheStory.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PassTheStory.Web.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}