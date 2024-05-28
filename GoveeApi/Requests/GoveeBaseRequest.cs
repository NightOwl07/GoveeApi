namespace GoveeApi.Requests
{
    public abstract class GoveeBaseRequest
    {
        public abstract string Endpoint { get; }

        public abstract HttpMethod Method { get; }
    }
}
