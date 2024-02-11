using SchoolApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student GetById(object id);
        void Add(Student obj);
        void Update(Student obj);
        void Delete(Student obj);
        void Save();
    }
}
