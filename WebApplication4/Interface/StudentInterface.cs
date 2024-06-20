using Microsoft.AspNetCore.Mvc;
using WebApplication4.Dto;

namespace WebApplication4.Interface
{
    public interface StudentInterface
    {
        Task<StudentModel> AddStudent(StudentModel student);
        Task<StudentModel> GetStudentByUId(string UId);
        Task<List<StudentModel>> GetAllStudent();
        Task<StudentModel> UpdateStudent(StudentModel student);
        Task<string> DeleteStudent(string UId);
        Task<StudentModel> AddStudentByMakePostRequest(StudentModel studentModel);

        Task<StudentModel> GetStudentByMakeGetRequest(string UId);
    }
}
