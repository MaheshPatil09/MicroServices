using Microsoft.Azure.Cosmos;
using WebApplication4.Common;
using WebApplication4.Entities;

namespace WebApplication4.Cosmos
{
    public class CosmosService : ICosmosService
    {
        public readonly CosmosClient _cosmosClient;
        public readonly Container _container;

        public CosmosService(CosmosClient cosmosClient)
        {
            _container =  cosmosClient.GetContainer(Credentials.databaseName,Credentials.containerName);

        }

        public async Task<StudentEntity> AddStudent(StudentEntity studentEntity)
        {
            var response = await _container.CreateItemAsync(studentEntity);
            return response;
        }

        public async Task<List<StudentEntity>> GetAllStudent()
        {
            var response = _container.GetItemLinqQueryable<StudentEntity>(true).Where(q => q.Active == true && q.Archived == false && q.DocumentType == Credentials.docType).ToList();
            return response;
        }
        public async Task<StudentEntity> GetStudentByUId(string UId)
        {
            var response = _container.GetItemLinqQueryable<StudentEntity>(true).Where(q => q.Active == true && q.Archived == false && q.DocumentType == Credentials.docType).FirstOrDefault();
            return response;
        }

        public async Task Replaceasync(dynamic entity)
        {
            var response =  await _container.ReplaceItemAsync(entity,entity.UId);
        }

    }
}
