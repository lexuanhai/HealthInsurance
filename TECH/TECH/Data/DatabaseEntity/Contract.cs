using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TECH.SharedKernel;

namespace TECH.Data.DatabaseEntity
{
    [Table("Contract")]
    public class Contract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? EmailId { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? ContractNo { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? Subject { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string? Message { get; set; }
    }
}
