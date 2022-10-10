﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TECH.Areas.Admin.Models
{
    public class PoliciesModelView
    {
        public int PolicyId { get; set; }
        public string? PolicyName { get; set; }
        public string? PolicyDesc { get; set; }
        public string? Amount { get; set; }
        public string? Emi { get; set; }
        public int? CompanyId { get; set; }
        public string? HospitalId { get; set; }
    }
}