using Microsoft.AspNetCore.Mvc;
using RESTFulAPI.Data;
using RESTFulAPI.Services;

namespace RESTFulAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService = null)
        {
            _studentService = studentService;
        }

        [HttpGet]
        //Get: api/students
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _studentService.GetAllAsync();
        }

        [HttpGet("{id}")]
        //Get: api/students/5
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var result= await _studentService.GetByIdAsync(id);
            if (result==null)
            {
                return NotFound();
            }
            return result;
        }

        [HttpPut("{id}")]
        //Put: api/students/5
        public async Task<ActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }
            if (!await _studentService.StudentExist(id))
            {
                return NotFound();
            }
            await _studentService.UpdateStudentAsync(student);
            return NoContent();
        }

        [HttpPost]
        //Post: api/students
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            var result = await _studentService.InsertStudentAsync(student);

            return CreatedAtAction("GetStudent",new {id=student.Id},student);
        }

        [HttpDelete("{id}")]
        //Delete: api/students/5
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student==null)
            {
                return NotFound();
            }
            await _studentService.DeleteAsync(id);
            return student;
        }
    }
}
