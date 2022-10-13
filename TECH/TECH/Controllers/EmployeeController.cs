using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public JsonResult ChangePassWordNew(string oldPassword,string newPassword)
        {
            int status = 0;
            if (!string.IsNullOrEmpty(oldPassword) && !string.IsNullOrEmpty(newPassword))
            {
                if (oldPassword.ToLower().Trim() == newPassword.ToLower().Trim())
                {
                    status = 1;
                }
                var userString = _httpContextAccessor.HttpContext.Session.GetString("UserInfor");
                var user = new EmpRegisterModelView();
                if (userString != null)
                {
                    user = JsonConvert.DeserializeObject<EmpRegisterModelView>(userString);
                    if (user != null && user.Empno > 0)
                    {
                        var userModel = _empRegisterService.GetByid(user.Empno);
                        if (userModel != null)
                        {
                            if (userModel.PassWord.ToLower().Trim() == oldPassword.ToLower().Trim() && 
                                userModel.PassWord.ToLower().Trim() != newPassword.ToLower().Trim())
                            {
                               var statusChange = _empRegisterService.UpdateChangePassword(user.Empno, newPassword.Trim());
                                if (statusChange)
                                    status = 3;
                            }
                            else
                            {
                                status = 2;
                            }

                        }
                    }

                }
            }
            return Json(new { status = status });
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

        public IActionResult UpdateEmployee(int employeeId)
        {
            var data = _empRegisterService.GetByid(employeeId);
            return View(data);
        }


        [HttpPost]
        public JsonResult Update(EmpRegisterModelView empRegisterModelView)
        {
            bool status = false;
            if (empRegisterModelView != null)
            {
                status = _empRegisterService.Update(empRegisterModelView);               
            }
            return Json(new { status = status });
        }

        [HttpPost]
        public JsonResult Add(EmpRegisterModelView empRegisterModelView)
        {
            bool status = false;
            if (empRegisterModelView != null)
            {
                int id = _empRegisterService.Add(empRegisterModelView);
                if (id > 0)
                {
                    status = true;
                }
            }
            return Json(new { status = status });
        }

        public IActionResult ResgisterEmployee()
        {
            return View();
        }
        public IActionResult ListEmployee()
        {
            var data = _empRegisterService.GetAllEmployee();
            return View(data);
        }
        

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var result = _empRegisterService.Deleted(id);
            _empRegisterService.Save();
            return Json(new
            {
                success = result
            });
        }


    }
}