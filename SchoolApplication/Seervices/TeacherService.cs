using SchoolApplication.Entities;
using SchoolApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Seervices
{
    public class TeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            this._teacherRepository = teacherRepository;
        }
        public void CreateTeacher(Teacher s)
        {
            _teacherRepository.Add(s);

        }
        //public void CreateSchool(School s)
        //{
        //    _teacherRepository.AddSchool(s);

        //}
        public void UpdateTeacher(Teacher s)
        {

            _teacherRepository.Update(s);
        }
        public bool DeleteTeacher(string id)
        {
          return  _teacherRepository.Delete(id);

        }
        public IEnumerable<Teacher> GetAllTeachers()
        {
            return _teacherRepository.GetAll();
        }
        public void save()
        {
            _teacherRepository.Save();
        }
        public Teacher GetTeacherById(object id)
        {
            return _teacherRepository.GetById(id);
        }
      
    }
}
