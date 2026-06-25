using AutoMapper;
using FlightBooking.Dtos.CheckInDtos;
using FlightBooking.Entities;
using FlightBooking.Services.BookingServices;
using FlightBooking.Services.CheckInServices;
using FlightBooking.Settings;       
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CheckInController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly ICheckInService _checkInService;

        public CheckInController(IBookingService bookingService, ICheckInService checkInService)
        {
            _bookingService = bookingService;
            _checkInService = checkInService;
        }

        public async Task<IActionResult> Index(string id)
        {
            ViewBag.FlightNumber = TempData["flightnumber"];
            ViewBag.DepartureTime = TempData["DepartureTime"];
            ViewBag.ArrivalTime = TempData["ArrivalTime"];

            var gate = await _bookingService.GetGateByPassengerIdAsync(id);
            var passenger = await _bookingService.GetPassengerNameByIdAsync(id);
            var pnrNumber = await _bookingService.GetPnrByPassengerIdAsync(id);

            ViewBag.Name = passenger.Name;
            ViewBag.Surname = passenger.Surname;
            ViewBag.PnrNumber = pnrNumber;
            ViewBag.Gate = gate;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CompleteCheckInDto completeCheckInDto)
        {
            await _checkInService.CompleteCheckInAsync(completeCheckInDto);
            return RedirectToAction("Test");
        }
    }
}
