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
    public class ClassRoomRepository : IClassRoomRepository
    {
        private readonly SchoolAppDbContext _context;

        public ClassRoomRepository(SchoolAppDbContext context)
        {
            _context = context;
        }
        public void Add(ClassRoom obj)
        {
            _context.Set<ClassRoom>().Add(obj);
        }

        public bool Delete(string id)
        {
            var existing = _context.Set<ClassRoom>().Find(id);
            if (existing != null)
            {

                _context.Set<ClassRoom>().Remove(existing);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public IEnumerable<ClassRoom> GetAll()
        {
            return _context.Set<ClassRoom>().ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public ClassRoom Update(ClassRoom obj)
        {
            

                var entry = _context.ClassRooms.Find(obj.Id);
            if (entry != null)
            {
                _context.Entry(entry).CurrentValues.SetValues(obj);
                _context.Entry(entry).State = EntityState.Modified;
                // _context.Students.Update(entry);
                _context.SaveChanges();
                return entry;
            }
            return null;

           
        }
    }
}
