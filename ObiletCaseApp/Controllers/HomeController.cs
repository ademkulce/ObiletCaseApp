using Microsoft.AspNetCore.Mvc;
using ObiletCaseApp.Models.ViewModels;
using ObiletCaseApp.Services.Abstract;

namespace ObiletCaseApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IObiletService _obiletService;

        public HomeController(IObiletService obiletService)
        {
            _obiletService = obiletService;
        }
        public async Task<IActionResult> Index(int? originId, int? destinationId, DateTime? departureDate)
        {           
            var session = await _obiletService.CreateSessionAsync();
          
            var locations = await _obiletService.GetBusLocationsAsync(session.SessionId,session.DeviceId,null);

        
            var viewModel = new IndexViewModel
            {
                Locations = locations,
                SelectedOriginId = originId,
                SelectedDestinationId = destinationId,
                SelectedDate = departureDate ?? DateTime.Today.AddDays(1)
            };

            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
