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
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly SchoolAppDbContext _context;

        public BaseRepository(SchoolAppDbContext context)
        {
           
            _context = context;
        }
        public void Add(T obj)
        {
            _context.Set<T>().Add(obj);
        }

        public void Delete(string id)
        {
            try
            {

                var existing = _context.Set<T>().Find(id);
                _context.Set<T>().Remove(existing);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No Data to update" + ex.Message);
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(object id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            try
            {
              //  var entry = _context.Set<T>().FirstOrDefault(e => e.Id == obj.Id);
             //   _context.Entry(entry).CurrentValues.SetValues(obj);



            }
            catch (Exception ex)
            {
                Console.WriteLine("No student to update" + ex.Message);
            }
        }
    }
}
