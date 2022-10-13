using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TECH.SharedKernel;

namespace TECH.Data.DatabaseEntity
{
    [Table("FeedBack")]
    public class FeedBack
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? UserName { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? EmailId { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string? Feedback { get; set; }
    }
}
