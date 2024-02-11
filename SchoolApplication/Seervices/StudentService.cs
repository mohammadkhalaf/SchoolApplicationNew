using Microsoft.EntityFrameworkCore;
using SchoolApplication.Entities;
using SchoolApplication.Repositories;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Seervices
{
    public class StudentService
    {
      
        private readonly IStudentRepository _studentRepo;

        public StudentService(IStudentRepository studentRepository)
        {

            _studentRepo = studentRepository;
        }
        public void CreateStudnet(string sName, int sGrade, string sphonenumber)
        {
            //   _studentRepo.Add(s);
            Student s = new Student()
            {
                Id = Guid.NewGuid().ToString(),
                Name = sName,
                PhoneNumber = sphonenumber
            };
            s.Grades.Add(new Grade()
            {
                MarkId = Guid.NewGuid().ToString(),
                Grade1 = sGrade,
                Grade2 = 10,
                Grade3 = 10,
                StudentId = s.Id

            }); 
                _studentRepo.Add(s);

            }

        public  void updateprocess()
        {
            var student = GetAllStudents();
            student.Name = AnsiConsole.Ask<string>(" New student name");
            student.PhoneNumber= AnsiConsole.Ask<string>(" New student Phone Number");
            UpdateStudent(student);
        }
        public void Deleteprocess()
        {
            var student = GetAllStudents();
            DeleteStudent(student);
           
        }
        public void UpdateStudent(Student s)
        {

            _studentRepo.Update(s);
        }


        public void DeleteStudent(Student obj)
        {
             _studentRepo.Delete(obj);

        }
         internal void ShowStudents(Student? stu)
        {
            var panel = new Panel($@"StudentName: {stu.Name}  
                                 PhoneNumber:  {stu.PhoneNumber}
                                 ");
            panel.Header = new PanelHeader("Student Info");
          //  panel.Padding(2, 2, 2, 2);
            AnsiConsole.Write(panel);
        }
        public Student GetAllStudents()
        {
            var AllStudents = _studentRepo.GetAll();
            var stuArray = AllStudents.Select(x => x.Name).ToArray();
            var options = AnsiConsole.Prompt(new SelectionPrompt<string>().
                Title("Choose Student").AddChoices(stuArray));
            var id = AllStudents.Single(x => x.Name == options).Id;
            var stu = _studentRepo.GetById(id);
            return stu;
          
        }
        public void save()
        {
            _studentRepo.Save();
        }
      public  Student GetStudentById(object id)
        {
            return _studentRepo.GetById(id);
        }
    }
}
