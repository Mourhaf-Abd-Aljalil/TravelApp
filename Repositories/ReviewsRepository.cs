using ProjectTourism.ClassDTO;
using ProjectTourism.Data;
using ProjectTourism.Entities;

namespace ProjectTourism.Repositories
{
    public class ReviewsRepository : IReviews
    {

        public IEnumerable<ReviewsDTO> GetAllReviews()
        {
            var context = new AppDbContext();

            var Reviews = context.Reviews.
                        Select(Review => new ReviewsDTO
                        {
                          ReviewId = Review.ReviewId,
                          TripId = (int)Review.TripId,
                          Rating = (int)Review.Rating,
                          Comment = Review.Comment,
                          ReviewDate = (DateTime)Review.ReviewDate,

                        }).ToList();

            return Reviews;
        }
        public Review FindReviewByID(int Id)
        {
            var context = new AppDbContext();

            var Review = context.Reviews.Find(Id);

            return Review;
        }

        public List<TripRatingDTO> GetTripRatings()
        {
            var context = new AppDbContext();

            var Review = context.Trips.Join(context.Reviews,T => T.TripId, R => R.TripId, 
                (T, R) => new TripRatingDTO
                {
                    TripName = T.Title,
                    Rating = (int)R.Rating,
                }).ToList();

            return Review;
        }
        //select T.Title as TripName, R.Comment, R.Rating, R.ReviewDate from Trip T
        //join Review R on R.Trip_Id = T.TripID
        public List<TripReviewDTO> GetTripReviews()
        {
            var context = new AppDbContext();

            var Review = context.Trips.Join(context.Reviews, T => T.TripId, R => R.TripId,
                (T, R) => new TripReviewDTO
                {
                    TripName = T.Title,
                    Comment = R.Comment,
                    Rating = (int)R.Rating,
                    ReviewDate = (DateTime)R.ReviewDate,
                }).ToList();

            return Review;
        }
    }

}
