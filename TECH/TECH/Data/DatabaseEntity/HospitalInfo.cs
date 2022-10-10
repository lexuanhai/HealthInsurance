using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TECH.SharedKernel;

namespace TECH.Data.DatabaseEntity
{
    [Table("HospitalInfo")]
   public class HospitalInfo
    {
        [Key]
        [Column(TypeName = "varchar(50)")]
        public string HospitalId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? HospitalName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? PhoneNo { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? Location { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? Url { get; set; }
    }
}
