namespace GoveeApi.Requests
{
    public class GoveeDeviceStateRequest : GoveeBaseRequest
    {
        public override string Endpoint => "/router/api/v1/device/state";

        public override HttpMethod Method => HttpMethod.Post;

        public required DeviceStatePayload Payload { get; set; }
    }

    public class DeviceStatePayload(string sku, string device)
    {
        public Guid RequestId = Guid.NewGuid();

        public StatePayload Payload = new StatePayload(sku, device);

        public class StatePayload(string sku, string device)
        {
            public string SKU = sku;
            public string Device = device;
        }
    }
}
