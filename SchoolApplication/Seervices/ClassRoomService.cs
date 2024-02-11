using SchoolApplication.Entities;
using SchoolApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Seervices
{
    public class ClassRoomService
    {

       
        private readonly IClassRoomRepository _classRoomRepo;

        public ClassRoomService(IClassRoomRepository classRoomRepo)
        {
           _classRoomRepo = classRoomRepo;
        }
        public void CreateClass(ClassRoom s)
        {
            _classRoomRepo.Add(s);

        }
        public void UpdateClass(ClassRoom s)
        {

            _classRoomRepo.Update(s);
        }
        public void DeleteClass(string id)
        {
            _classRoomRepo.Delete(id);

        }
        public IEnumerable<ClassRoom> GetAllClasses()
        {
            return _classRoomRepo.GetAll();
        }
        public void save()
        {
            _classRoomRepo.Save();
        }
       
    }
}
