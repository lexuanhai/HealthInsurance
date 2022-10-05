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
        public int CompanyId { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string? CompanyName { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string? Address { get; set; }
        [Column(TypeName = "nvarchar(200)")]

        public string? CompanyUrl { get; set; }
    }
}
