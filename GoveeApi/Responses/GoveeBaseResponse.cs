namespace GoveeApi.Responses
{
    public abstract class GoveeBaseResponse
    {
        public int Code { get; set; }
        public string? Message { get; set; }
    }
}
