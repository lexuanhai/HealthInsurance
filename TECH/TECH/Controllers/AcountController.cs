using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TECH.Models;

namespace TECH.Controllers
{
    public class AcountController : Controller
    {

        public AcountController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LoginEmployView()
        {
            return View();
        }
        [HttpGet]
        public JsonResult LoginEmploy()
        {
            var data = "";
            return Json(new { data = data });
        }
        public IActionResult LoginEmployAdmin()
        {
            return View();
        }
        [HttpGet]
        public JsonResult LoginAdmin()
        {
            var data = "";
            return Json(new { data = data });
        }

    }
}