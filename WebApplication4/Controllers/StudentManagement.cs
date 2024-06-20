using Microsoft.AspNetCore.Mvc;
using WebApplication4.Dto;
using WebApplication4.Interface;

namespace WebApplication4.Controllers
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class StudentManagement : Controller
    {
        public readonly StudentInterface _student;

        public StudentManagement(StudentInterface student)
        {
            _student = student;
        }

        [HttpPost]

        public async Task<StudentModel> AddStudent(StudentModel student)
        {
            var response = await _student.AddStudent(student);
            return response;
        }

        [HttpGet]

        public async Task<StudentModel> GetStudentByUId(string UId)
        {
            var response = await _student.GetStudentByUId(UId);
            return response;
        }
        [HttpGet]

        public async Task<List<StudentModel>> GetAllStudent()
        {
            var response = await _student.GetAllStudent();
            return response;
        }
        [HttpPost]

        public async Task<StudentModel> UpdateStudent(StudentModel student)
        {
            var response = await _student.UpdateStudent(student);
            return response;
        }
        [HttpPost]

        public async Task<string> DeleteStudent(string UId)
        {
            var response = await _student.DeleteStudent(UId);
            return response;
        }

        [HttpPost]

        public async Task<IActionResult> AddStudentByMakePostRequest(StudentModel studentModel)
        {
            var response = await _student.AddStudentByMakePostRequest(studentModel);
            return Ok(response);
        }

        [HttpGet]

        public async Task<IActionResult> GetStudentByMakeGetRequest(string UId)
        {
            var response = await _student.GetStudentByMakeGetRequest(UId);
            return Ok(response);
        }
    }
}
