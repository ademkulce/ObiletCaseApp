using ObiletCaseApp.Models.Api.RequestModels;
using ObiletCaseApp.Models.Api.ResponseModels;

namespace ObiletCaseApp.Services.Abstract
{
    public interface IObiletService
    {
        Task<List<BusLocationResponse.DataItem>> GetBusLocationsAsync(string sessionId,string deviceId, string search = "");
        Task<GetSessionResponse.SessionData> CreateSessionAsync();
        Task<List<JourneyResponse.JourneyItem>> GetJourneysAsync(JourneyRequest request);
    }
}
