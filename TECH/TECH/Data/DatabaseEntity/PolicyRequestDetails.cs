using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TECH.SharedKernel;

namespace TECH.Data.DatabaseEntity
{
    [Table("PolicyRequestDetails")]
    public class PolicyRequestDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestId { get; set; }
        public DateTime? RequestDate { get; set; }
        public int? Empno { get; set; }
        public int? PoicyId { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? PolicyName { get; set; }
        [Column(TypeName = "decimal(10,0)")]
        public decimal? PolicyAmount { get; set; }
        [Column(TypeName = "decimal(10,0)")]
        public decimal? Emi { get; set; }
        public int? CompanyId { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? CompanyName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? Status { get; set; }
    }
}
