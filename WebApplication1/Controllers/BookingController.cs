using HostelManagement.Models;
using HostelManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HostelManagement.controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BookingMethods _bookingService;

        public BookingController(BookingMethods bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> BookRoom(Booking booking)
        {
            var result = await _bookingService.BookRoom(booking);
            if (result)
            {
                return Ok("Booking successful");
            }
            else
            {
                return BadRequest("Booking failed");
            }
        }
    }
}
