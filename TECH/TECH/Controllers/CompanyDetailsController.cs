using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using TECH.Models;
using TECH.Service;

namespace TECH.Controllers
{
    public class CompanyDetailsController : Controller
    {
        private readonly ICompanyDetailsService _companyDetailsService;
        public CompanyDetailsController(ICompanyDetailsService companyDetailsService)
        {
            _companyDetailsService = companyDetailsService;
        }
        
        public JsonResult GetComanyById(int id)
        {
            var data = _companyDetailsService.GetByid(id);            
            return Json(new { data = data });
        }
        public IActionResult AddView()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddCompany(CompanyDetailsModelView companyDetailsModelView)
        {
            bool status = false;
            if (companyDetailsModelView != null)
            {
                int Id = _companyDetailsService.Add(companyDetailsModelView);
                if (Id > 0)
                {
                    status = true;
                }
            }
            return Json(new { status = status });
        }
        public JsonResult GetAll()
        {
            var data = _companyDetailsService.GetAll();
            return Json(new { data = data });
        }
    }
}