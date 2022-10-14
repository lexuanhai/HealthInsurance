using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TECH.Models
{
    public class PoliciesonEmployeesModelView
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int? Empno { get; set; }
        public int PolcyId { get; set; }
        public string? PolcyName { get; set; }
        public decimal? PolicyAmount { get; set; }
        public decimal? EMI { get; set; }
        public decimal? PolicyDuration { get; set; }
        public DateTime? PstartDate { get; set; }
        public DateTime? Penddate { get; set; }
        public int? CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public string? Medical { get; set; }
    }
    public class PolicyeeRequestModelView
    {
        public PoliciesonEmployeesModelView? PoliciesonEmployeesModelView { get; set; }
        public PolicyRequestDetailsModelView? PolicyRequestDetailsModelView { get; set; }
    }
}
