using ProjectTourism.ClassDTO;
using ProjectTourism.Entities;

namespace ProjectTourism.Repositories
{
    public interface IBooking
    {
        IEnumerable<BookingDTO> GetAllBookings();
        List<BookingDTO> FindBookingByID(int Id);

    }
}
