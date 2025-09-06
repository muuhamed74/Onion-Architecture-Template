namespace Onion_Architecture_Template.Helpers.Errors
{
    public class ApiException : ApiResponce
    {
        public ApiException(int statuscode, string? message = null, string? details = null) : base(statuscode, message)
        {
            Details = details;
        }
        public string? Details { get; set; }
    }
}
