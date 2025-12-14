using ProjectTourism.ClassDTO;
using ProjectTourism.Entities;

namespace ProjectTourism.Repositories
{
    public interface IReviews
    {
        IEnumerable<ReviewsDTO> GetAllReviews();
        Review FindReviewByID(int Id);
        List<TripRatingDTO> GetTripRatings();
        List<TripReviewDTO> GetTripReviews();
    }
}
