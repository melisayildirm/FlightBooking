using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Controllers
{
    public class DeafultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
