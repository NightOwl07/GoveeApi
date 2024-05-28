using GoveeApi.Requests;
using GoveeApi.Responses;

namespace GoveeApi
{
    public class Capability
    {

    }

    public class GoveeDevice(GoveeApiClient client, DeviceData deviceData)
    {
        private DeviceData _deviceData = deviceData;

        private GoveeApiClient _client = client;
    
        public async Task<GoveeDeviceStateResponse?> GetState()
        {
            if (_deviceData == null)
            {
                throw new Exception("device data is null");
            }

            var request = new GoveeDeviceStateRequest() { Payload = new DeviceStatePayload(_deviceData.SKU, _deviceData.Device) };
            return await _client.Run<GoveeDeviceStateRequest, GoveeDeviceStateResponse>(request);
        }

        public async Task TurnOff()
        {
            var capability = new DeviceCapability()
            {
                Type = "devices.capabilities.on_off",
                Instance = "powerSwitch",
                Parameters = new CapabilityParameter()
                {
                    Options =
                    [
                        new Option()
                        {
                            Name = "on",
                            Value = 0
                        }
                    ]
                }
            };

            await this.Control(capability);
        }

        public async Task TurnOn()
        {
            var capability = new DeviceCapability()
            {
                Type = "devices.capabilities.on_off",
                Instance = "powerSwitch",
                Parameters = new CapabilityParameter()
                {
                    Options =
                    [
                        new Option()
                        {
                            Name = "on",
                            Value = 1
                        }
                    ]
                }
            };

            await this.Control(capability);
        }

        public async Task Control(DeviceCapability capability)
        {
            var request = new GoveeDeviceControlRequest();
            var response = await _client.Run<GoveeDeviceControlRequest, GoveeDeviceListResponse>(request);
        }
    }
}
