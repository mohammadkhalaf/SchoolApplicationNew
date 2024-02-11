using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SchoolApplication.Context;
using SchoolApplication.Entities;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolAppDbContext _context;

        public StudentRepository(SchoolAppDbContext context)
        {
            _context = context;
        }
        public void Add(Student obj)
        {
            _context.Set<Student>().Add(obj);
        }

        public void Delete(Student obj)
        {
            // _context.Set<Student>().Remove(obj);
            try
            {
                var entry = _context.Students.Find(obj.Id);
                if (entry != null)
                {
                    _context.Remove(entry);
                    _context.Entry(entry).State = EntityState.Deleted;
                }
                else Console.WriteLine("no student to delete");
            }
            catch (Exception ex)
            {
                Console.WriteLine("No student to delete");
            }



        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Set<Student>().ToList();
        }

        public Student GetById(object id)
        {
            return _context.Set<Student>().Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Student obj)
        {
            try
            {
                
                var entry = _context.Students.Find(obj.Id);
                if (entry != null)
                {
                    entry.Name = entry.Name;
                    _context.Entry(entry).CurrentValues.SetValues(obj);
                    _context.Entry(entry).State = EntityState.Modified;
                      _context.SaveChanges();
                }
                else Console.WriteLine("no student to Update");


            }
            catch (Exception ex)
            {
                Console.WriteLine("No student to update");
            }
          //  _context.SaveChanges();
           // _context.Attach(obj);
           // _context.Entry(obj).State = EntityState.Modified;
           //_context.Set<Student>().Update(obj);
        }
    }
}