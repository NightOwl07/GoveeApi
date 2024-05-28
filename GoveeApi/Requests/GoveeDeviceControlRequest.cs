using GoveeApi.Responses;

namespace GoveeApi.Requests
{
    public class GoveeDeviceControlRequest : GoveeBaseRequest
    {
        public override string Endpoint => "/router/api/v1/device/control";

        public override HttpMethod Method => HttpMethod.Post;
    }


    public class DeviceControlPayload(string sku, string device)
    {
        public Guid RequestId = Guid.NewGuid();

        public ControlPayload Payload = new ControlPayload(sku, device);

        public class ControlPayload(string sku, string device)
        {
            public string SKU = sku;
            public string Device = device;
            public DeviceCapability Capability = new();
        }
    }
}
