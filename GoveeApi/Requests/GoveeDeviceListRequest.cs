namespace GoveeApi.Requests
{
    public class GoveeDeviceListRequest : GoveeBaseRequest
    {
        public override string Endpoint => "/router/api/v1/user/devices";

        public override HttpMethod Method => HttpMethod.Get;
    }
}
