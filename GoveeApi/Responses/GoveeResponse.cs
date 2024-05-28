namespace GoveeApi.Responses
{
    public class DeviceCapability
    {
        public string? Type { get; set; }
        public string? Instance { get; set; }
        public CapabilityParameter? Parameters { get; set; }
    }

    public class CapabilityParameter
    {
        public string? DataType { get; set; }
        public List<Option>? Options { get; set; }
        public string? Unit { get; set; }
        public Range? Range { get; set; }
        public List<Field>? Fields { get; set; }
    }

    public class Option
    {
        public string? Name { get; set; }
        public int Value { get; set; }
    }

    public class Range
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public int Precision { get; set; }
    }

    public class Field
    {
        public string? FieldName { get; set; }
        public Range? Size { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public int Precision { get; set; }
        public bool Required { get; set; }
        public string? DataType { get; set; }
        public Range? ElementRange { get; set; }
        public string? ElementType { get; set; }
    }

    public class DeviceData
    {
        public string? SKU { get; set; }
        public string? Device { get; set; }
        public string? DeviceName { get; set; }
        public string? Type { get; set; }
        public List<DeviceCapability>? Capabilities { get; set; }
    }

    public class GoveeDeviceListResponse : GoveeBaseResponse
    {
        public List<DeviceData>? Data { get; set; }
    }
}
