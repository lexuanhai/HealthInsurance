using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using TECH.Areas.Admin.Models;
using TECH.Models;
using TECH.Service;

namespace TECH.Controllers
{
    public class PolicyRequestDetailsController : Controller
    {
        private readonly IPolicyRequestDetailsService _policyRequestDetailsService;
        public PolicyRequestDetailsController(IPolicyRequestDetailsService policyRequestDetailsService)
        {
            _policyRequestDetailsService = policyRequestDetailsService;
        }
        public IActionResult Add()
        {
            return View();
        }
    }
}