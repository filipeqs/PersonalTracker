using System.Net;

namespace Api.Errors
{
    public class ApiValidationErrorResponse : ApiErrorResponse
    {
        public ApiValidationErrorResponse() : base((int)HttpStatusCode.BadRequest)
        {
        }

        public IEnumerable<string> Errors { get; set; }
    }
}
