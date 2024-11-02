namespace HRManagement.API.ResponseModels
{
    public class APIResponse<T>
    {
            public bool Success { get; set; }
            public string Message { get; set; }
            public T Data { get; set; }
            public List<string> Errors { get; set; }

            public APIResponse(bool success, string message, T data) 
            {
                Success = success;
                Message = message;
                Data = data;
                Errors = new List<string>();
            }

            public APIResponse(bool success, string message, T data, List<string> errors)
            {
                Success = success;
                Message = message;
                Data = data;
                Errors = errors;
            }

            public static APIResponse<T> SuccessResponse(T data, string message = "Request successful") 
            {
                return new APIResponse<T>(true, message, data);
            }

            public static APIResponse<T> ErrorResponse(List<string> errors, string message = "An error occurred") 
            {
                return new APIResponse<T>(false, message, default(T), errors);
            }
        }
    
}
