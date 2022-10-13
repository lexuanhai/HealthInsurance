using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TECH.Models
{
    public class FeedBackModelView
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? EmailId { get; set; }
        public string? Feedback { get; set; }
    }
}
