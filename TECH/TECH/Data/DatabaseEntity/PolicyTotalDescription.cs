using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TECH.SharedKernel;

namespace TECH.Data.DatabaseEntity
{
    [Table("PolicyTotalDescription")]
    public class PolicyTotalDescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? PolicyId { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? PolicyName { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string? PolicyDes { get; set; }
        [Column(TypeName = "decimal(10,0)")]
        public decimal? PolicyAmount { get; set; }
        [Column(TypeName = "decimal(10,0)")]
        public decimal? EMI { get; set; }
        public int? PolicyDurationinMonths { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? CompanyName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? MedicalId { get; set; }
        public int? CompanyId { get; set; }
    }
}
