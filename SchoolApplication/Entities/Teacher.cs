using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Entities
{
    public class Teacher
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string  Salary { get; set; }
        public ICollection<ClassRoom?> ClassRooms { get; set; } = new HashSet<ClassRoom>();
    }
}
