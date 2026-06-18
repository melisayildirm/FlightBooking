using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.ViewComponents
{
    public class _DefaultFooterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() {
            return View();
        }
    }
}
