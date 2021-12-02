using System.Net;

namespace Api.Errors
{
    public class ApiValidationErrorResponse : ApiErrorResponse
    {
        public ApiValidationErrorResponse(IEnumerable<string> errors) : base((int)HttpStatusCode.BadRequest)
        {
            Errors = errors;
        }

        public IEnumerable<string> Errors { get; set; }
    }
}
