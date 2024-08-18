using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsApi.DataSmulation;
using StudentsApi.Models;

namespace StudentsApi.Controllers
{
    [Route("api/StudentApi")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        [HttpGet("All",Name ="GetAllStudents")]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            return Ok(StudentDataSimulation.StudentList);
        }

        [HttpGet("Passed",Name = "GetPassedStudents")]
        public ActionResult<IEnumerable<Student>> GetPassedStudents()
        {
            var PassedStudent = StudentDataSimulation.StudentList.Where((p) => p.Grade > 70);
            return Ok(PassedStudent);
        }

        [HttpGet("Find/{Id:int}",Name = "GetStudentByID")]
        public ActionResult<IEnumerable<Student>> GetStudentByID(int Id)
        {
            if (Id <= 0) return BadRequest();
            foreach (var item in StudentDataSimulation.StudentList)
            {
                if (item.Id == Id)
                {
                    return Ok(item);
                }
            }
            return NotFound();
        }

        [HttpPost("Add",Name ="AddNewStudent")]
        public ActionResult<IEnumerable<Student>> AddNewStudent([FromForm] Student student)
        {
            foreach (var item in StudentDataSimulation.StudentList)
            {
                if (item.Id == student.Id || student.Id <= 0)
                {
                    return BadRequest("Id should be unqui and should be valad");
                }
            }

            StudentDataSimulation.StudentList.Add(new Student { Id = student.Id, Name = student.Name, Age = student.Age, Grade = student.Grade });
            return NoContent();
        }

        [HttpPut("Update" ,Name ="UpdateStudentByID")]
        public ActionResult<IEnumerable<Student>> UpdateStudentByID([FromForm] Student student)
        {
            if (student.Id <= 0) return BadRequest();
            foreach (var item in StudentDataSimulation.StudentList)
            {
                if (item.Id == student.Id)
                {
                    item.Name = student.Name;
                    item.Age = student.Age;
                    item.Grade = student.Grade;
                    return NoContent();
                }
            }
            return NotFound();
        }

        [HttpDelete("Delete{Id:int}",Name ="DeleteStudentByID")]
        public ActionResult<IEnumerable<Student>> DeleteStudentByID(int Id)
        {
            if (Id <= 0) return BadRequest();
            var List = StudentDataSimulation.StudentList;
            foreach (var item in List)
            {
                if (item.Id == Id)
                {
                    List.Remove(item);
                    return NoContent();
                }
            }
            return NotFound();
        }
    }
}
