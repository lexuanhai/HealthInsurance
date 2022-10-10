﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using TECH.Areas.Admin.Models;
using TECH.Models;
using TECH.Service;

namespace TECH.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmpRegisterService _empRegisterService;
        public IHttpContextAccessor _httpContextAccessor;
        public EmployeeController(IEmpRegisterService empRegisterService,
            IHttpContextAccessor httpContextAccessor)
        {
            _empRegisterService = empRegisterService;
            _httpContextAccessor = httpContextAccessor;
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
        public JsonResult LoginEmploy(string userName,string passWord)
        {
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
        public IActionResult ChangePassWord()
        {
            var userString = _httpContextAccessor.HttpContext.Session.GetString("UserInfor");
            var user = new EmpRegisterModelView();
            if (userString != null)
            {
                user = JsonConvert.DeserializeObject<EmpRegisterModelView>(userString);
                if (user != null)
                {
                    return View(user);
                }
               
            }
            return Redirect("/Employee");
        }
        public IActionResult ViewEmployee()
        {
            var userString = _httpContextAccessor.HttpContext.Session.GetString("UserInfor");
            var user = new EmpRegisterModelView();
            if (userString != null)
            {
                user = JsonConvert.DeserializeObject<EmpRegisterModelView>(userString);
                if (user != null && user.Empno > 0)
                {
                    var model = _empRegisterService.GetByid(user.Empno);
                    if (model != null && model.Empno > 0)
                    {
                        return View(model);
                    }                    
                }
            }
            return Redirect("/Employee");
        }

    }
}