using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using TECH.Models;
using TECH.Service;

namespace TECH.Controllers
{
    public class PoliciesonEmployeesController : Controller
    {
        private readonly IPoliciesonEmployeesService _policiesonEmployeesService;
        private readonly IPolicyRequestDetailsService _policyRequestDetailsService;
        private IHttpContextAccessor _httpContextAccessor;
        public PoliciesonEmployeesController(IPoliciesonEmployeesService policiesonEmployeesService,
            IPolicyRequestDetailsService policyRequestDetailsService,
        IHttpContextAccessor httpContextAccessor)
        {
            _policiesonEmployeesService = policiesonEmployeesService;
            _httpContextAccessor = httpContextAccessor;
            _policyRequestDetailsService = policyRequestDetailsService;
    }
        public IActionResult AddView()
        {
            return View();
        }
        public IActionResult AddDetailView(int id,int requestId)
        {
            var data = _policiesonEmployeesService.GetPoliciesonEmployeesId(id, requestId);
            //return View();
            return View(data);
        }

        [HttpPost]
        public JsonResult Add(PoliciesonEmployeesModelView policiesonEmployeesModelView)
        {
            bool status = false;
            if (policiesonEmployeesModelView != null)
            {
                int Id = _policiesonEmployeesService.Add(policiesonEmployeesModelView);
                if (Id > 0)
                {
                    status = true;
                }
            }
            return Json(new { status = status });
        }
        //[HttpGet]
        //public JsonResult GetAllPolicyRequest()
        //{
        //    var data = _policyRequestDetailsService.GetAllPoliciesRequest();
        //    return Json(new { data = data });
        //}
    }
}