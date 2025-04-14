using ObiletCaseApp.Models.Api.RequestModels;
using ObiletCaseApp.Models.Api.ResponseModels;

namespace ObiletCaseApp.ApiClients.Abstract
{
    public interface IObiletApiClient
    {
        Task<GetSessionResponse> GetSessionAsync();
        Task<List<BusLocationResponse.DataItem>> GetBusLocationsAsync(string sessionId, string deviceId, string searchText = "");
        Task<List<JourneyResponse.JourneyItem>> GetJourneysAsync(JourneyRequest request);
    }
}
