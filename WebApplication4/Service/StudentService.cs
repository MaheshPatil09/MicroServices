using AutoMapper;
using Newtonsoft.Json;
using WebApplication4.Common;
using WebApplication4.Cosmos;
using WebApplication4.Dto;
using WebApplication4.Entities;
using WebApplication4.Interface;

namespace WebApplication4.Service
{
    public class StudentService : StudentInterface
    {
        public readonly ICosmosService _cosmosService;
        public  readonly IMapper _mapper;
        public StudentService(ICosmosService cosmosService,IMapper mapper)
        {
            _cosmosService = cosmosService;
            _mapper = mapper;
        }

        public async Task<StudentModel> AddStudent(StudentModel studentModel)
        {
            var student = _mapper.Map<StudentEntity>(studentModel);
            student.Initialize(true,Credentials.docType,"Mahesh","Mahesh");
            var response = await _cosmosService.AddStudent(student);
            var responseModel =  _mapper.Map<StudentModel>(response);
            return responseModel;

        }

        public async Task<List<StudentModel>> GetAllStudent()
        {
            var response = await _cosmosService.GetAllStudent();
            List<StudentModel> students = new List<StudentModel>();
            foreach (var student in response)
            {
                var responseModel = _mapper.Map<StudentModel>(student);
                students.Add(responseModel);
            }
            return students;
        }

          public async Task<StudentModel> GetStudentByUId(string UId)
        {
              var response = await _cosmosService.GetStudentByUId(UId);
              var responseModel = _mapper.Map<StudentModel>(response);
              return responseModel;
        }

        public async Task<StudentModel> UpdateStudent(StudentModel studentModel)
        {
            var student = await _cosmosService.GetStudentByUId(studentModel.UId);
            student.Active = false;
            await _cosmosService.Replaceasync(student);
            student.Initialize(false, Credentials.docType, "Sahil", "Sahil");
            _mapper.Map(studentModel,student);
            var reponse = await _cosmosService.AddStudent(student);
            return _mapper.Map<StudentModel>(reponse);  
        }

        public async Task<string> DeleteStudent(string UId)
        {
            var response = await _cosmosService.GetStudentByUId(UId);
            response.Active = false;
            response.Archived = true;
            await _cosmosService.Replaceasync(response);
            response.Initialize(false, Credentials.docType, "Om", "Om");
            response.Active = false;
            return "Deleted Succsefully";
        }

        public async Task<StudentModel> AddStudentByMakePostRequest(StudentModel studentModel)
        {
            var serializeObj = JsonConvert.SerializeObject(studentModel);
            var requestObj = await HttpFileHelper.MakePostRequest(Credentials.StudentUrl,Credentials.AddStudentEndPoint,serializeObj);
            var responseObject = JsonConvert.DeserializeObject<StudentModel>(requestObj);
            return responseObject;

        }
        public async Task<StudentModel>GetStudentByMakeGetRequest(string UId)
        {
            var requestObj = await HttpFileHelper.MakeGetRequest(Credentials.StudentUrl, Credentials.GetStudentEndPoint);
            var reponseObject = JsonConvert.DeserializeObject<StudentModel>(requestObj);
            return reponseObject;
        }
    }
}
