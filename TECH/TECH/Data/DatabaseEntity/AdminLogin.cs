using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TECH.SharedKernel;

namespace TECH.Data.DatabaseEntity
{
    [Table("AdminLogin")]
    public class AdminLogin : DomainEntity<int>
    {
        [Column(TypeName = "varchar(50)")]
        public string? UserName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? PassWord { get; set; }
    }
}
