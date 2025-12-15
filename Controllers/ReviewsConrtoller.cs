using Microsoft.AspNetCore.Mvc;
using ProjectTourism.ClassDTO;
using ProjectTourism.Repositories;

namespace ProjectTourism.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviews Review;
        public ReviewsController(IReviews Review)
        {
            this.Review = Review;

        }
        [HttpGet("GetAllReviews")]
        public ActionResult<IEnumerable<ReviewsDTO>> GetAllReviews()
        {
            var Reviews = Review.GetAllReviews();

            return (Reviews == null) ? BadRequest() : Ok(Reviews);
        }

        [HttpGet("FindReviewBy{Id}")]
        public ActionResult<ReviewsDTO> FindReviewByID(int Id)
        {

            var ReviewByID = Review.FindReviewByID(Id);

            return ReviewByID != null ? Ok(ReviewByID) : BadRequest();

        }
        [HttpGet("GetTripRatings")]
        public ActionResult<List<TripRatingDTO>> GetTripRatings()
        {
            var Reviews = Review.GetTripRatings();

            return (Reviews == null)? BadRequest("There are no Reviews") : Ok(Reviews);

        }
        [HttpGet("GetTripReviews")]
        public ActionResult<List<TripReviewDTO>> GetTripReviews()
        {
            var Reviews = Review.GetTripReviews();

            return (Reviews == null) ? BadRequest("There are no Reviews") : Ok(Reviews);

        }
    }
   


}


