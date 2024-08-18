using StudentsApi.Models;

namespace StudentsApi.DataSmulation
{
    public class StudentDataSimulation
    {
        public static readonly List<Student> StudentList = new List<Student>
        { 
            new Student{Id = 1, Name = "Omar" , Age = 23 , Grade = 80},
            new Student{Id = 2, Name = "Alaa" , Age = 25 , Grade = 77},
            new Student{Id = 3, Name = "Mohamad" , Age = 21 , Grade = 90},
            new Student{Id = 4, Name = "Majd" , Age = 22 , Grade = 60},

        };

    }
}
