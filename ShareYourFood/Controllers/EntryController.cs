using ShareYourFood.Models;
using ShareYourFood.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShareYourFood.Controllers
{
    public class EntryController : Controller
    {
        readonly IUserService _userService;
        readonly IFoodService _foodService;

        public EntryController(IUserService userService, IFoodService foodService)
        {
            _userService = userService;
            _foodService = foodService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CreateNewFood()
        {
            return Json(new FoodModel(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveFood(FoodModel food)
        {
            _foodService.SaveFood(food);
            return RedirectToAction("Index");
        }

        public JsonResult Report(EntryModel model)
        {
            var entryWithCountModel = _userService.ReportModel(model);
            TempData["model"] = entryWithCountModel;
            return Json(new { url = Url.Action("Index", "Feed") });
        }

        public JsonResult InitModel()
        {
            var entryModel = new EntryModel()
            {
                AvailableFood = _foodService.GetAllFood()
            };
            return Json(entryModel, JsonRequestBehavior.AllowGet);
        }
    }
}