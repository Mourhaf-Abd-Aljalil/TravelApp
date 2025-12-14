using ProjectTourism.ClassDTO;
using ProjectTourism.Entities;

namespace ProjectTourism.Repositories
{
    public interface IAttraction
    {
        IEnumerable<AttractionDTO> GetAllAttractions();
        Attraction FindAttractionByID(int Id);
        List<TripAttractionDTO> GetTripAttractions();

    }
}
