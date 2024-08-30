using _01_EF_Core;
using System;

public class Program
{
  static  public void GetAllStudents()
    {
        using (var context = new AppDBContext())
        {
            foreach (var item in context.Students)
            {
                Console.WriteLine(item);
            }
        }
    }

    static public void InsertStudent( string Name, int Age, int Grade)
    {
        using (var context = new AppDBContext())
        {
            var NewStudent = new Students { Name = Name, Age = Age, Grade = Grade };
            var student = context.Students.Add(NewStudent);
            context.SaveChanges();
            Console.WriteLine(NewStudent.Id);


        }
    }

    static public void UpdateStudent(int Id ,string Name, int Age ,  int Grade)
    {
        using (var context = new AppDBContext())
        {
            var student = context.Students.SingleOrDefault(x => x.Id == Id);           
            if (student != null)
            {
                student.Id = Id;
                student.Name = Name;
                student.Age = Age;
                student.Grade = Grade;
                context.Students.Update(student);

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Erorr with Update student");
            }
        }
    }

    static public void GetStudentById(int Id)
    {
        using (var context = new AppDBContext())
        {
            var student = context.Students.SingleOrDefault(x => x.Id == Id);
            if (student != null)
              Console.WriteLine(student);
            else
                Console.WriteLine($"Cant find students with id ={Id}");
        }
     
    }

    static public void DeleteStudent(int Id)
    {
        using (var context = new AppDBContext())
        {
            var student = context.Students.SingleOrDefault(x => x.Id == Id);
            if (student != null) 
            {
                context.Students.Remove(student);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Erorr with delete student");
            }
        }
    }


    static public void Main()
    {

       GetAllStudents();

     //    InsertStudent("NewName",99,99);

     //   UpdateStudent(13, "Sarah", 22, 98);

     //   GetStudentById(13);

    //    DeleteStudent(13);
    }
}
