using Microsoft.EntityFrameworkCore;
using SchoolApplication.Context;
using SchoolApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SchoolAppDbContext _context;

        public TeacherRepository(SchoolAppDbContext context)
        {
            _context = context;
        }
        public void Add(Teacher obj)
        {
            _context.Set<Teacher>().Add(obj);
        }
        public void AddSchool(School obj)
        {
            _context.Set<School>().Add(obj);

        }
        public bool Delete(string id)
        {

            var existing = _context.Set<Teacher>().Find(id);
            if (existing != null)
            {

                _context.Set<Teacher>().Remove(existing);
                _context.SaveChanges();
                return true;
            }
            else { Console.WriteLine("No student to delete"); }

            return false;
        }

        public IEnumerable<Teacher> GetAll()
        {
            return _context.Set<Teacher>().ToList();
        }

        public Teacher GetById(object id)
        {
            return _context.Set<Teacher>().Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Teacher obj)
        {
            try
            {

                var entry = _context.Teachers.Find(obj.Id);
                if (entry != null)
                {
                    entry.Name = entry.Name;
                    _context.Entry(entry).CurrentValues.SetValues(obj);
                    _context.Entry(entry).State = EntityState.Modified;
                    // _context.Students.Update(entry);
                    _context.SaveChanges();
                }
                else Console.WriteLine("no Teacher to Update");

            }
            catch(Exception ex)
            {
                Console.WriteLine("No teacher to Update" + ex.Message);
            }
            //  _context.SaveChanges();
        }
    }
}
