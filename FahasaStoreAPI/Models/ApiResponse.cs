namespace FahasaStore.Models
{
    public class ApiResponse<T> where T : class
    {
        public ApiResponse()
        {
        }
        public ApiResponse(int status, bool error, string? message, T? data)
        {
            Status = status;
            Error = error;
            Message = message;
            Data = data;
        }

        public int Status { get; set; }
        public bool Error { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
