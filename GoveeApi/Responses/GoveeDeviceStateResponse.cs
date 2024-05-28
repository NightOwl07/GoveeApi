namespace GoveeApi.Responses
{
    public class GoveeDeviceStateResponse : GoveeBaseResponse
    {
        public Payload? Payload { get; set; }
    }

    public class PayloadState
    {
        public object? Value { get; set; }
    }

    public class PayloadCapability
    {
        public string? Type { get; set; }
        public string? Instance { get; set; }
        public PayloadState? State { get; set; }
    }

    public class Payload
    {
        public string? SKU { get; set; }
        public string? Device { get; set; }
        public List<PayloadCapability>? Capabilities { get; set; }
    }
}
