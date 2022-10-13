using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TECH.Models
{
    public class ContractModelView
    {
        public int Id { get; set; }
        public string? EmailId { get; set; }
        public string? ContractNo { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
    }
}
