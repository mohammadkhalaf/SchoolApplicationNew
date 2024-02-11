using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Entities
{
    public class Grade
    {
        [Key]
        public string MarkId { get; set; }
        [ForeignKey("Id")]
        public string? StudentId { get; set; }
        public int Grade1 { get; set; }
        public int Grade2 { get; set; }
        public int Grade3 { get; set; }

    }
}
