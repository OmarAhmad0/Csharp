using System.ComponentModel.DataAnnotations;

namespace StudentsApi.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }


    }
}
