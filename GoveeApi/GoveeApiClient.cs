using GoveeApi.Requests;
using GoveeApi.Responses;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace GoveeApi
{
    public class GoveeApiClient(string apiKey)
    {
        private readonly HttpClient _httpClient = new();

        private readonly string _apiKey = apiKey;

        private readonly string _apiUrl = "https://openapi.api.govee.com";

        public async Task<R?> Run<T, R>(T request) where T : GoveeBaseRequest where R : GoveeBaseResponse, new()
        {
            JsonSerializerOptions serializerOptions = new()
            {
                PropertyNameCaseInsensitive = true,
                IncludeFields = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var url = $"{_apiUrl}{request.Endpoint}";

            using var requestMessage = new HttpRequestMessage(request.Method, url);
            requestMessage.Headers.Add("Govee-API-Key", _apiKey);

            if (request is GoveeDeviceStateRequest stateRequest)
            {
                var serializedPayload = JsonSerializer.Serialize(stateRequest.Payload, serializerOptions);
                requestMessage.Content = new StringContent(serializedPayload, Encoding.UTF8, MediaTypeHeaderValue.Parse("application/json"));
            }

            using var response = await _httpClient.SendAsync(requestMessage);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var responseObject = JsonSerializer.Deserialize<R>(content, serializerOptions);

            return responseObject;
        }
    }
}
