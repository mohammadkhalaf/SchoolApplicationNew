// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SchoolApplication.Context;
using SchoolApplication.Entities;
using SchoolApplication.Repositories;
using SchoolApplication.Seervices;
using Spectre.Console;




var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddScoped<IStudentRepository, StudentRepository>();
    services.AddScoped<ITeacherRepository, TeacherRepository>();
    services.AddScoped<IClassRoomRepository, ClassRoomRepository>();

    services.AddScoped<StudentService>();
    services.AddScoped<TeacherService>();
    services.AddScoped<ClassRoomService>();
    services.Configure<ConsoleLifetimeOptions>(opts => opts.SuppressStatusMessages = true);

    services.AddDbContext<SchoolAppDbContext>(x =>
    x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\A\Desktop\SchoolApplication\SchoolApplication\Data\SchoolDb.mdf;Integrated Security=True;Connect Timeout=30"));

}).Build();
builder.Start();
var student1 = builder.Services.GetRequiredService<StudentService>();
var teacher1 = builder.Services.GetRequiredService<TeacherService>();
var classRoom = builder.Services.GetRequiredService<ClassRoomService>();




School sch = new School()
{

    SchoolName = "Future International School"

};

Console.WriteLine("----------------------- Welcome to crud App School System------------------");
Console.WriteLine();

int result;
int result1;
bool flag;
int operation;

Student s = new Student();
Teacher t = new Teacher();
ClassRoom c = new ClassRoom();
var options = AnsiConsole.Prompt(new SelectionPrompt<menuoptions>()
    .Title("what would you like to do")
    .AddChoices(menuoptions.Studnts,
                menuoptions.Teachers,
                menuoptions.ClassRooms));





switch (options)
{
    case menuoptions.Studnts:
        while (true)
        {
            var StuoOptions = AnsiConsole.Prompt(new SelectionPrompt<StudentOptions>()
    .Title("what would you like to do")
    .AddChoices(StudentOptions.Insert_New_Student,
                StudentOptions.Update_Student,
                StudentOptions.Delete_Student,
                StudentOptions.SHow_All_Students));
            switch (StuoOptions)
            {
                case StudentOptions.Insert_New_Student:

                    Console.WriteLine("please Insert Student data");
                    Console.WriteLine("please Insert Student Name");
                    var stuName = Console.ReadLine();
                    Console.WriteLine("please Insert Student PhoneNumber");
                    var phone = Console.ReadLine();
                    int studgrade;
                    do
                    {
                        Console.WriteLine("please Insert Grade");
                        flag = int.TryParse(Console.ReadLine(), out studgrade);
                    } while (!flag);





                    student1.CreateStudnet(stuName, studgrade, phone);
                    student1.save();
                    Console.WriteLine("student added successfuly");
                    break;
                case StudentOptions.Update_Student:


                    // Console.WriteLine("please insert student name you want to update");
                    // var updatedstudent = student.GetStudentById(s.Id);

                    //Console.WriteLine("please Insert new Student Name");
                    //var stuName1 = Console.ReadLine();
                    //Console.WriteLine("please Insert new Student PhoneNumber");
                    //var phone1 = Console.ReadLine();
                    //var id = s.Id;
                    //Student s2 = new Student()
                    //{
                    //    Id = id,
                    //    Name = stuName1,
                    //    PhoneNumber = phone1
                    //};
                    //student1.UpdateStudent(s2);
                    student1.updateprocess();
                    //  student1.save();
                    Console.WriteLine("student  Updated successfuly");

                    break;
                case StudentOptions.Delete_Student:
                     student1.Deleteprocess();
                     student1.save();
                    //if (student1.Deleteprocess())
                        Console.WriteLine("student  deleted successfuly");
                  //  else Console.WriteLine();
                    break;

                case StudentOptions.SHow_All_Students:
                    Console.WriteLine("Students list");
                    var AllStudents = student1.GetAllStudents();
                    
                    student1.ShowStudents(AllStudents);
                    
                    break;
                default:
                    Console.WriteLine("please enter options from 1 to 4");
                    break;

            }

        }
    case menuoptions.Teachers:
        while (true)
        {
            var TeachOptions = AnsiConsole.Prompt(new SelectionPrompt<TeacherOptions>()
    .Title("what would you like to do")
    .AddChoices(TeacherOptions.Insert_New_Techer,
                TeacherOptions.Update_Techer,
                TeacherOptions.Delete_Teacher,
                TeacherOptions.SHow_All_Teachers));
            switch (TeachOptions)
            {
                case TeacherOptions.Insert_New_Techer:

                    Console.WriteLine("------------------please Insert Teacher data--------------");
                    Console.WriteLine("please Insert teacher Name");
                    var techName = Console.ReadLine();
                    Console.WriteLine("please Insert Teacher Salary");
                    var salary = Console.ReadLine();

                    t = new Teacher()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = techName,
                        Salary = salary
                    };


                    teacher1.CreateTeacher(t);
                    teacher1.save();
                    Console.WriteLine("Teacher added successfuly");
                    break;
                case TeacherOptions.Update_Techer:

                    Console.WriteLine("please Insert new Teacher Name");
                    var NewName = Console.ReadLine();
                    Console.WriteLine("please Insert new Teacher Salary");
                    var newsalary = Console.ReadLine();
                    var id = t.Id;
                    t = new Teacher()
                    {
                        Id = id,
                        Name = NewName,
                        Salary = newsalary
                    };
                    teacher1.UpdateTeacher(t);
                    //   teacher1.save();
                    Console.WriteLine("Teacher  Updated successfuly");

                    break;
                case TeacherOptions.Delete_Teacher:
                    bool x = teacher1.DeleteTeacher(t.Id);
                    //student1.save();
                    if (x)
                        Console.WriteLine("Teacher  deleted successfuly");
                    else Console.WriteLine("");
                    break;

                case TeacherOptions.SHow_All_Teachers:
                    Console.WriteLine("Teachers list");
                    var AllTeachers = teacher1.GetAllTeachers();
                    foreach (var stu in AllTeachers)
                    {
                        Console.Write("Teacher Name = " + stu.Name);
                        // Console.WriteLine("student id=  " + stu.Id);
                        Console.WriteLine("    ---  Teacher salary =  " + stu.Salary);

                    }
                    break;
                default:
                    Console.WriteLine("please enter options from 1 to 4");
                    break;

            }

        }
        break;
    case menuoptions.ClassRooms:
        while (true)
        {

            var ClassOptions = AnsiConsole.Prompt(new SelectionPrompt<ClassroomOptions>()
                .Title("what would you like to do")
                .AddChoices(ClassroomOptions.Insert_New_ClassRoom,
                            ClassroomOptions.Update_ClassRoom,
                            ClassroomOptions.Delete_ClassRoom,
                            ClassroomOptions.SHow_All_ClassRooms));
            switch (ClassOptions)
            {
                case ClassroomOptions.Insert_New_ClassRoom:

                    Console.WriteLine("------------------please Insert ClassRoom data--------------");
                    Console.WriteLine("please Insert ClassRoom ");
                    var classroom = Console.ReadLine();


                    c = new ClassRoom()
                    {
                        Id = Guid.NewGuid().ToString(),
                        ClassNo = classroom

                    };


                    classRoom.CreateClass(c);
                    classRoom.save();
                    Console.WriteLine("classRoom added successfuly");
                    break;
                case ClassroomOptions.Update_ClassRoom:

                    Console.WriteLine("please Insert new ClassNo");
                    var Newclass = Console.ReadLine();

                    var id = c.Id;
                    c = new ClassRoom()
                    {
                        Id = id,
                        ClassNo = Newclass

                    };
                    classRoom.UpdateClass(c);

                    Console.WriteLine("ClassRoom  Updated successfuly");

                    break;
                case ClassroomOptions.Delete_ClassRoom:
                    classRoom.DeleteClass(c.Id.ToString());
                    //  classRoom.save();
                    Console.WriteLine("ClassRoom  deleted successfuly");
                    break;

                case ClassroomOptions.SHow_All_ClassRooms:
                    Console.WriteLine("ClassRoom list");
                    var AllClasses = classRoom.GetAllClasses();
                    foreach (var stu in AllClasses)
                    {
                        Console.WriteLine("ClassNo = " + stu.ClassNo);
                    }
                    break;
                default:
                    Console.WriteLine("please enter options from 1 to 4");
                    break;

            }

        }
        break;

    default:
        Console.WriteLine("you entered wrong choice");
        break;
        

}








enum menuoptions
{
    Studnts,
    Teachers,
    ClassRooms
}
enum StudentOptions
{
    Insert_New_Student,
    Update_Student,
    Delete_Student,
    SHow_All_Students
}
enum TeacherOptions
{
    Insert_New_Techer,
    Update_Techer,
    Delete_Teacher,
    SHow_All_Teachers
}
enum ClassroomOptions
{
    Insert_New_ClassRoom,
    Update_ClassRoom,
    Delete_ClassRoom,
    SHow_All_ClassRooms
}




