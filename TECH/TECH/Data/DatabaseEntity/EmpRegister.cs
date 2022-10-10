using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TECH.SharedKernel;

namespace TECH.Data.DatabaseEntity
{
    [Table("EmpRegister")]
    public class EmpRegister
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Empno { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string? Designation { get; set; }
        public DateTime? JoinDate { get; set; }
        [Column(TypeName = "decimal(10,0)")]
        public decimal? Salary { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? FirstName { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? LastName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? UserName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? PassWord { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string? Address { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? ContactNo { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? State { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? Country { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? City { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? PolicyStatus { get; set; }
        public int? PolicyId { get; set; }
    }
}
