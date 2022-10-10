using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TECH.Areas.Admin.Models
{
    public class EmpRegisterModelView
    {
        public int Empno { get; set; }
        public string? Designation { get; set; }
        public DateTime? JoinDate { get; set; }
        public decimal? Salary { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? PassWord { get; set; }
        public string? Address { get; set; }
        public string? ContactNo { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? PolicyStatus { get; set; }
        public int? PolicyId { get; set; }
    }
}
