using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Entities
{
    public class ClassRoom
    {
        [Key] 
        public string Id { get; set; }
        public string ClassNo { get; set; }
        public ICollection<Teacher?> Teachers { get; set; } = new HashSet<Teacher>();

    }
}
