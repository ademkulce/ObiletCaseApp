using Microsoft.AspNetCore.Mvc;
using ObiletCaseApp.Models.Api.RequestModels;
using ObiletCaseApp.Models.ViewModels;
using ObiletCaseApp.Services.Abstract;

namespace ObiletCaseApp.Controllers
{
    public class JourneyController : Controller
    {
        private readonly IObiletService _obiletService;

        public JourneyController(IObiletService obiletService)
        {
            _obiletService = obiletService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int originId, int destinationId, DateTime departureDate)
        {
            //  Session oluştur
            var session = await _obiletService.CreateSessionAsync();

            // JourneyRequest hazırla
            var request = new JourneyRequest
            {
                Data = new JourneyRequest.DataModel
                {
                    OriginId = originId,
                    DestinationId = destinationId,
                    DepartureDate = departureDate.ToString("yyyy-MM-dd")
                },
                DeviceSession = new JourneyRequest.DeviceSessions
                {
                    SessionId = session.SessionId,
                    DeviceId = session.DeviceId
                },
                Date = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss"),
                Language = "tr-TR"
            };

            //  Seferleri çek
            var journeys = await _obiletService.GetJourneysAsync(request);

            var locations = await _obiletService.GetBusLocationsAsync(session.SessionId, session.DeviceId);


            var origin = locations.FirstOrDefault(x => x.Id == originId);
            var destination = locations.FirstOrDefault(x => x.Id == destinationId);

            //  View'e ViewModel ile gönder
            var viewModel = new JourneyViewModel
            {
                Journeys = journeys,
                OriginId = originId,
                DestinationId = destinationId,
                DepartureDate = departureDate,
                OriginName = origin?.Name ?? "Bilinmiyor",
                DestinationName = destination?.Name ?? "Bilinmiyor"
            };

            return View(viewModel);
        }
    }
}
