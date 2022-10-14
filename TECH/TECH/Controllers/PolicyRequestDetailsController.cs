using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using TECH.Models;
using TECH.Service;

namespace TECH.Controllers
{
    public class PolicyRequestDetailsController : Controller
    {
        private readonly IPolicyRequestDetailsService _policyRequestDetailsService;
        private IHttpContextAccessor _httpContextAccessor;
        public PolicyRequestDetailsController(IPolicyRequestDetailsService policyRequestDetailsService,
            IHttpContextAccessor httpContextAccessor)
        {
            _policyRequestDetailsService = policyRequestDetailsService;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddRequestDetails(PolicyRequestDetailsModelView policyRequestDetailsModelView)
        {
            var userString = _httpContextAccessor.HttpContext.Session.GetString("UserInfor");
            bool status = false;
            if (!string.IsNullOrEmpty(userString))
            {
               var user = JsonConvert.DeserializeObject<EmpRegisterModelView>(userString);
                if (user != null && user.Empno > 0)
                {
                    if (policyRequestDetailsModelView != null)
                    {
                        policyRequestDetailsModelView.Empno = user.Empno;
                        int Id = _policyRequestDetailsService.Add(policyRequestDetailsModelView);
                        if (Id > 0)
                        {
                            status = true;
                        }
                    }

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
        public IActionResult GetAllPolicyRequest()
        {
            var data = _policyRequestDetailsService.GetAllPoliciesRequest();
            return View(data);
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var result = _policyRequestDetailsService.Deleted(id);
            _policyRequestDetailsService.Save();
            return Json(new
            {
                success = result
            });
        }

    }
}