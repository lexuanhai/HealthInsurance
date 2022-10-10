using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TECH.SharedKernel;

namespace TECH.Data.DatabaseEntity
{
    [Table("Policies")]
    public class Policies 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PolicyId { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? PolicyName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? PolicyDesc { get; set; }
        [Column(TypeName = "decimal(10,0)")]
        public string? Amount { get; set; }
        [Column(TypeName = "decimal(10,0)")]
        public string? Emi { get; set; }
        public int? CompanyId { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? HospitalId { get; set; }
    }
}
