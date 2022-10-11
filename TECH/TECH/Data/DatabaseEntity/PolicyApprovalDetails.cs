using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TECH.SharedKernel;

namespace TECH.Data.DatabaseEntity
{
    [Table("PolicyApprovalDetails")]
    public class PolicyApprovalDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PolcyId { get; set; }
        public int? RequestId { get; set; }
        public DateTime? Date { get; set; }
        [Column(TypeName = "decimal(10,0)")]
        public decimal? Amount { get; set; }
        [Column(TypeName = "char(3)")]
        public string? Status { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? Reason { get; set; }
    }
}
