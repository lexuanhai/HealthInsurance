using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using TECH.Models;
using TECH.Service;

namespace TECH.Controllers
{
    public class FeedBackController : Controller
    {
        private readonly IFeedBackService _feedBackService;
        public IHttpContextAccessor _httpContextAccessor;
        public FeedBackController(IFeedBackService feedBackService)
        {
            _feedBackService = feedBackService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Add(FeedBackModelView feedBackModelView)
        {
            bool status = false;
            if (feedBackModelView != null)
            {
                int id = _feedBackService.Add(feedBackModelView);
                if (id > 0)
                {
                    status = true;
                }
            }
            return Json(new { status = status });
        }       

    }
}