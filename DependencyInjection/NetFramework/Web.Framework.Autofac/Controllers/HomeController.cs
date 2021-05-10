using Glav.CacheAdapter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Framework.Autofac.Models;

namespace Web.Framework.Autofac.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICacheProvider _cacheProvider;

        public HomeController(ICacheProvider cacheProvider)
        {
            _cacheProvider = cacheProvider;
        }
        public ActionResult Index()
        {
            var model = new DataModel
            {
                CachedDateTime = _cacheProvider.Get<string>(TimeSpan.FromMinutes(1), () => { return DateTime.Now.ToLongTimeString(); })
            };
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}