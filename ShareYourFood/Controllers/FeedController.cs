using ShareYourFood.Models;
using ShareYourFood.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ShareYourFood.Controllers
{
    public class FeedController : Controller
    {
        readonly IUserService _userService;
        readonly IFoodService _foodService;

        private const int COUNT = 15;

        public FeedController(IUserService userService, IFoodService foodService)
        {
            _userService = userService;
            _foodService = foodService;
        }
        
        public ActionResult Index()
        {
            var serializer = new JavaScriptSerializer();
            ViewBag.EntryModel = serializer.Serialize(TempData["model"]);
            return View();
        }

        public JsonResult GetLastFeed() =>
            Json(_userService.GetLastEntries(COUNT), behavior: JsonRequestBehavior.AllowGet);
    }
}