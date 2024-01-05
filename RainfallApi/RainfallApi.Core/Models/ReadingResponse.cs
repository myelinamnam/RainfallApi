namespace RainfallApi.Core.Models
{

    public class RainfallReadingResponse
    {
        public List<RainfallReading> Readings { get; set; }
    }

    public class RainfallReading
    {
        public DateTime DateMeasured { get; set; }
        public decimal AmountMeasured { get; set; }
    }

    public class ErrorResponses
    {
        public string Message { get; set; }
        public List<ErrorDetail> Detail { get; set; }
    }

    public class ErrorDetail
    {
        public string PropertyName { get; set; }
        public string Message { get; set; }
    }

}
