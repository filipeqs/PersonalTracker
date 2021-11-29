using System.Net;

namespace Api.Errors
{
    public class ApiErrorResponse
    {
        public ApiErrorResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                (int)HttpStatusCode.BadRequest => "A bad request, you have made",
                (int)HttpStatusCode.Unauthorized => "Authorized, you are not",
                (int)HttpStatusCode.NotFound => "Resource found, it was not",
                (int)HttpStatusCode.InternalServerError => "Error are the path to the dark side. Errors lead to anger. Anger leads to hate. Hate leads to career change",
                _ => null
            };
        }
    }
}
