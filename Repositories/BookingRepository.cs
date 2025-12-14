using ProjectTourism.ClassDTO;
using ProjectTourism.Data;
using ProjectTourism.Entities;

namespace ProjectTourism.Repositories
{
    public class BookingRepository : IBooking
    {

        public IEnumerable<BookingDTO> GetAllBookings()
        {
            var context = new AppDbContext();

            var Bookings = context.Bookings.
                        Select(Booking => new BookingDTO
                        {
                          BookingId = Booking.BookingId,
                          CostBooking = Booking.CostBooking,
                          Status = Booking.Status,
                          BookingDate = Booking.BookingDate

                        }).ToList();

            return Bookings;
        }
        public List<BookingDTO> FindBookingByID(int Id)
        {
            var context = new AppDbContext();

            var Booking = context.Bookings.Where(Booking => Booking.BookingId == Id)
                      .Select(Booking => new BookingDTO
                      {
                          BookingId = Booking.BookingId,
                          CostBooking = Booking.CostBooking,
                          Status = Booking.Status,
                          BookingDate = Booking.BookingDate

                      }).ToList();

            return Booking;
        }
    }

}
