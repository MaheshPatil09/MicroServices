namespace WebApplication4.Common
{
    public class Credentials
    {
        public static string databaseName = Environment.GetEnvironmentVariable("databaseName");
        public static string containerName = Environment.GetEnvironmentVariable("containerName");
        public static string cosmosEndpoint = Environment.GetEnvironmentVariable("cosmosUrl");
        public static string primaryKey = Environment.GetEnvironmentVariable("primaryKey");
        public static readonly string StudentUrl = Environment.GetEnvironmentVariable("studentUrl");
        public static readonly string AddStudentEndPoint = "/api/Student/AddStudent";
        public static readonly string GetStudentEndPoint = "/api/Student/GetStudentByUId";
        internal static string docType = "employee";
        internal static string createdBy = "Mahesh";
    }
}
