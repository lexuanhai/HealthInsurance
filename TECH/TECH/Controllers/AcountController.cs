using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using TECH.Models;
using TECH.Service;

namespace TECH.Controllers
{
    public class AcountController : Controller
    {
        private readonly IEmpRegisterService _empRegisterService;
        private readonly IAdminLoginService _adminLoginService;
        public IHttpContextAccessor _httpContextAccessor;
        public AcountController(IEmpRegisterService empRegisterService,
            IAdminLoginService adminLoginService,
            IHttpContextAccessor httpContextAccessor)
        {
            _empRegisterService = empRegisterService;
            _httpContextAccessor = httpContextAccessor;
            _adminLoginService = adminLoginService;
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
        public JsonResult LoginEmploy(string userName, string passWord)
        {
            bool status = false;
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(passWord))
            {
                var model = _empRegisterService.Login(userName, passWord);
                if (model != null)
                {
                    _httpContextAccessor.HttpContext.Session.SetString("UserInfor", JsonConvert.SerializeObject(model));
                    return Json(new
                    {
                        status = true,
                        isEmploy = true
                    });
                }
            }
            return Json(new
            {
                status = false
            });
        }
        public IActionResult LoginAdminView()
        {
            return View();
        }
        [HttpGet]
        public JsonResult LoginAdmin(string userName, string passWord)
        {
            bool status = false;
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(passWord))
            {
                var model = _adminLoginService.Login(userName, passWord);
                if (model != null)
                {
                    _httpContextAccessor.HttpContext.Session.SetString("UserAdminInfor", JsonConvert.SerializeObject(model));
                    return Json(new
                    {
                        status = true,
                        isEmploy = true
                    });
                }
            }
            return Json(new
            {
                status = false
            });
        }
        [HttpGet]
        public JsonResult LogOut()
        {

            var userString = _httpContextAccessor.HttpContext.Session.GetString("UserInfor");
            var userAdminString = _httpContextAccessor.HttpContext.Session.GetString("UserAdminInfor");            
            if (userString != null)
            {
                _httpContextAccessor.HttpContext.Session.Remove("UserInfor");
            }
            if (userAdminString != null)
            {               
                _httpContextAccessor.HttpContext.Session.Remove("UserAdminInfor");
            }

            return Json(new
            {
                status = true
            }) ;

        }

    }
}