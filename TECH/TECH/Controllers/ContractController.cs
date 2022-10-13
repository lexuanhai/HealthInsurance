using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using TECH.Models;
using TECH.Service;

namespace TECH.Controllers
{
    public class ContractController : Controller
    {
        private readonly IContractService _contractService;
        public IHttpContextAccessor _httpContextAccessor;
        public ContractController(IContractService contractService)
        {
            _contractService = contractService;
        }

        public IActionResult Index()
        {
            return View();
        }       

        [HttpPost]
        public JsonResult Add(ContractModelView contractModelView)
        {
            bool status = false;
            if (contractModelView != null)
            {
                int id = _contractService.Add(contractModelView);
                if (id > 0)
                {
                    status = true;
                }
            }
            return Json(new { status = status });
        }       

    }
}