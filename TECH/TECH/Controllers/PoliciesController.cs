using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using TECH.Areas.Admin.Models;
using TECH.Models;
using TECH.Service;

namespace TECH.Controllers
{
    public class PoliciesController : Controller
    {
        private readonly IPoliciesService _policiesService;
        public PoliciesController(IPoliciesService policiesService)
        {
            _policiesService = policiesService;
        }

        public IActionResult Index()
        {
            var data = _policiesService.GetAllPolicies();
            return View(data);
        }
        public IActionResult LoginEmployView()
        {
            return View();
        }
        public IActionResult AddView()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddPolicy(PoliciesModelView policiesModelView)
        {
            bool status = false;
            if (policiesModelView != null)
            {
                int Id = _policiesService.Add(policiesModelView);
                if (Id > 0)
                {
                    status = true;
                }
            }
            return Json(new { status = status });
        }
        [HttpGet]
        public JsonResult GetAllPolicy()
        {
            var data = _policiesService.GetAllPolicies();
            return Json(new { data = data });
        }
    }
}