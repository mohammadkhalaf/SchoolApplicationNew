using SchoolApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Repositories
{
   public interface  ITeacherRepository
    {
        IEnumerable<Teacher> GetAll();
        Teacher GetById(object id);
        void Add(Teacher obj);
        void AddSchool(School obj);
        void Update(Teacher obj);
        bool Delete(string id);
        void Save();
    }
}
