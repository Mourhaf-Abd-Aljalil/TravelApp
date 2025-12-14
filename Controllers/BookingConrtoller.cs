using Microsoft.AspNetCore.Mvc;
using ProjectTourism.ClassDTO;
using ProjectTourism.Repositories;

namespace ProjectTourism.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingConrtoller : ControllerBase
    {
        private readonly IBooking Booking;
        public BookingConrtoller(IBooking Booking)
        {
            this.Booking = Booking;

        }
        [HttpGet("GetAllBookings")]
        public ActionResult<IEnumerable<BookingDTO>> GetAllBookings()
        {
            var Bookings = Booking.GetAllBookings();

            return (Bookings == null) ? BadRequest() : Ok(Bookings);
        }

        [HttpGet("FindBookingBy{Id}")]
        public ActionResult<BookingDTO> FindBookingByID(int Id)
        {

            var BookingByID = Booking.FindBookingByID(Id);

            return BookingByID != null ? Ok(BookingByID) : BadRequest();

        }
    }
   


}
