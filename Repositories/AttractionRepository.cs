using ProjectTourism.ClassDTO;
using ProjectTourism.Data;
using ProjectTourism.Entities;
using System.Numerics;

namespace ProjectTourism.Repositories
{
    public class AttractionRepository : IAttraction
    {
        public IEnumerable<AttractionDTO> GetAllAttractions()
        {
            var context = new AppDbContext();

        var Attractions = context.Attractions.
                        Select(Attraction => new AttractionDTO
                        {
                            AttractionId = Attraction.AttractionId,
                            AttractionName = Attraction.AttractionName,
                            Description = Attraction.Description,
                            Location = Attraction.Location,
                      
                        }).ToList();

            return Attractions;
        }
        public Attraction FindAttractionByID(int Id)
        {
            var context = new AppDbContext();

            var Attraction = context.Attractions.Find(Id);

            return Attraction;
        }

        public List<TripAttractionDTO> GetTripAttractions()
        {
            var context = new AppDbContext();

            var TripAttraction = context.Trips
                 .Join(context.TripAttractions,
                 trip => trip.TripId,
                 TripAt => TripAt.TripId,
                 (trip, TripAt) => new { trip, TripAt })
                .Join(context.Attractions,
                 combined => combined.TripAt.AttractionId,
                 place => place.AttractionId,
                 (combined, place) => new TripAttractionDTO
                 {
                     TripName = combined.trip.Title,
                     AttractionName = place.AttractionName,
                     Description = place.Description,
                     Location = place.Location,
                 }).ToList();

            return TripAttraction;
        }
    }

}
