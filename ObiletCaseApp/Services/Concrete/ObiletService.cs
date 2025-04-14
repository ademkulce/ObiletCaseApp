using ObiletCaseApp.ApiClients.Abstract;
using ObiletCaseApp.Models.Api.RequestModels;
using ObiletCaseApp.Models.Api.ResponseModels;
using ObiletCaseApp.Services.Abstract;

namespace ObiletCaseApp.Services.Concrete
{
    public class ObiletService : IObiletService
    {
        private readonly IObiletApiClient _apiClient;

        public ObiletService(IObiletApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<BusLocationResponse.DataItem>> GetBusLocationsAsync(string sessionId, string deviceId, string search = null)
        {
            return await _apiClient.GetBusLocationsAsync(sessionId, deviceId, search);
        }

        public async Task<GetSessionResponse.SessionData> CreateSessionAsync()
        {
            var sessionResponse = await _apiClient.GetSessionAsync();
            return sessionResponse.Data;
        }

        public async Task<List<JourneyResponse.JourneyItem>> GetJourneysAsync(JourneyRequest request)
        {
            return await _apiClient.GetJourneysAsync(request);
        }
    }
}
