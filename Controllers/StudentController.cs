using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostgreSQLWebAPI.DataAccess;
using PostgreSQLWebAPI.Models;

namespace PostgreSQLWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IDataAccessProvider _dataAccessProvider;

        public StudentController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _dataAccessProvider.GetStudentRecords();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Student student)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                student.studentid = obj.ToString();
                _dataAccessProvider.AddStudentRecord(student);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{studentid}")]
        public Student Details(string studentid)
        {
            return _dataAccessProvider.GetStudentSingleRecord(studentid);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Student student)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateStudentRecord(student);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{studentid}")]
        public IActionResult DeleteConfirmed(string studentid)
        {
            var data = _dataAccessProvider.GetStudentSingleRecord(studentid);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteStudentRecord(studentid);
            return Ok();
        }
    }
}

