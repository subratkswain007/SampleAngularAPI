namespace SampleAngularAPI.Model
{
    public class ApiResponse
    {
        public object Result { get; set; }

        public string Message { get; set; }

        public string ErrorMessage { get; set; }

        public static ApiResponse CreateResponse(object result = null, string message = null, string errorMessage = null)
        {
            return new ApiResponse()
            {
                Result = result,
                Message = message,
                ErrorMessage = errorMessage
            };
        }

        public static ApiResponse CreateSuccessResponse(object result, string message = null)
        {
            return new ApiResponse()
            {
                Result = result,
                Message = message
            };
        }

        public static ApiResponse CreateFailureResponse(object result, string errorMessage = null)
        {
            return new ApiResponse()
            {
                Result = result,
                ErrorMessage = errorMessage
            };
        }
    }
}
