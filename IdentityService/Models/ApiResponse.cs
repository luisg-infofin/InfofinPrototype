namespace IdentityService.Models
{
    public class ApiResponse
    {
        public int StatusCode { get; set; } 
        public object? Data { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; } 
    }
}
