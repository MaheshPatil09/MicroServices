using WebApplication4.Entities;

namespace WebApplication4.Cosmos
{
    public interface ICosmosService
    {
        Task<StudentEntity> AddStudent(StudentEntity student);  
        Task<StudentEntity> GetStudentByUId(string id);

        Task<List<StudentEntity>> GetAllStudent();

        Task Replaceasync(dynamic entity);

    }
}
