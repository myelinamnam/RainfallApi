namespace RainfallApi.Core.Models
{
    public class InsertLogsRequest
    {
        public string ObjectId { get; set; }
        public string ObjectName { get; set; }
        public string Level { get; set; }
        public string Module { get; set; }
        public string ClassName { get; set; }
        public string ErrorMessage { get; set; }
        public string MethodName { get; set; }
        public string RequestUrl { get; set; }
        public string RequestJson { get; set; }
        public string Response { get; set; }
        public bool IsError { get; set; }
    }

}
