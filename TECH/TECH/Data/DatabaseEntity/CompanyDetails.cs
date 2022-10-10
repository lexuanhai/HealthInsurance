using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TECH.SharedKernel;

namespace TECH.Data.DatabaseEntity
{
    [Table("CompanyDetails")]
    public class CompanyDetails 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? CompanyName { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string? Address { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Phone { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? CompanyURL { get; set; }
    }
}
