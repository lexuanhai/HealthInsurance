using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TECH.SharedKernel;

namespace TECH.Data.DatabaseEntity
{
    [Table("EmpRegister")]
    public class Category
    {
        [Key]
        public int Empno { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string? Designation { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal? Salary { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string? FirstName { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string? LastName { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string? UserName { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string? PassWord { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string? Address { get; set; }

        public DateTime Joindate { get; set; }

        public DateTime? updated_at { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
