using GoveeApi;
using GoveeApi.Requests;
using GoveeApi.Responses;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var client = new GoveeApiClient("your-api-key-here");

        var request = new GoveeDeviceListRequest();
        var devices = await client.Run<GoveeDeviceListRequest, GoveeDeviceListResponse>(request);

        var device = new GoveeDevice(client, devices.Data[0]);
        var state = await device.GetState();

        device.TurnOn();

        var onOff = state.Payload.Capabilities.Find(f => f.Type == "devices.capabilities.on_off");
    }
}