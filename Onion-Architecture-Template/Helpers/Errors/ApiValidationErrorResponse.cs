namespace Onion_Architecture_Template.Helpers.Errors
{
    public class ApiValidationErrorResponse : ApiResponce
    {
        public ApiValidationErrorResponse() : base(400)
        {
        }
        public IEnumerable<string>? Errors { get; set; }

    }
 
}
