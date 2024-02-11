using SchoolApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Repositories
{
    public interface IClassRoomRepository
    {
        IEnumerable<ClassRoom> GetAll();
        void Add(ClassRoom obj);
        ClassRoom Update(ClassRoom obj);
        bool Delete(string id);
        void Save();
    }
}
