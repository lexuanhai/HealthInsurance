using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TECH.SharedKernel;

namespace TECH.Data.DatabaseEntity
{
    [Table("PoliciesonEmployees")]
    public class PoliciesonEmployees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //[Column(TypeName = "varchar(10)")]
        public int? Empno { get; set; }
        public int PolcyId { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? PolcyName { get; set; }
        [Column(TypeName = "decimal(10,0)")]
        public decimal? PolicyAmount { get; set; }
        [Column(TypeName = "decimal(10,0)")]
        public decimal? EMI { get; set; }
        [Column(TypeName = "decimal(10,0)")]
        public decimal? PolicyDuration { get; set; }
        public DateTime? PstartDate { get; set; }
        public DateTime? Penddate { get; set; }
        public int? CompanyId { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? CompanyName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? Medical { get; set; }
    }
}
