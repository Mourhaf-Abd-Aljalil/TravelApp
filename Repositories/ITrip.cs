using ProjectTourism.ClassDTO;
using ProjectTourism.Entities;

namespace ProjectTourism.Repositories
{
    public interface ITrip
    {
        IEnumerable<TripDTO> GetAllTrips();
        List<TripDTO> FindTripByID(int Id);
        int AddNewTrip(Trip NewTrip);
        bool UpdateTrip(Trip Trip);
        bool DeleteTrip(int Id);
    }
}
