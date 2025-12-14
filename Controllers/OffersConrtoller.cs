using Microsoft.AspNetCore.Mvc;
using ProjectTourism.ClassDTO;
using ProjectTourism.Repositories;

namespace ProjectTourism.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OffersConrtoller : ControllerBase
    {
        private readonly IOffers Offer;
        public OffersConrtoller(IOffers Offer)
        {
            this.Offer = Offer;

        }
        [HttpGet("GetAllOffers")]
        public ActionResult<IEnumerable<OffersDTO>> GetAllOffers()
        {
            var Offers = Offer.GetAllOffers();

            return (Offers == null) ? BadRequest() : Ok(Offers);
        }

        [HttpGet("FindOfferBy{Id}")]
        public ActionResult<OffersDTO> FindOfferByID(int Id)
        {

            var OfferByID = Offer.FindOfferByID(Id);

            return OfferByID != null ? Ok(OfferByID) : BadRequest();

        }
        [HttpGet]
        [Route("GetTripOffers")]
    public ActionResult<List<TripOfferDTO>> GetTripOffers()
        {
            var TripOffers = Offer.GetTripOffer();

            return (TripOffers == null) ? BadRequest("Has not Trip Offers") : Ok(TripOffers);
        }
        [HttpGet]
        [Route("GetTripOfferWithMoreThan")]
        public ActionResult<List<TripOfferDTO>> GetTripOfferWithMoreThan(int DiscountValue)
        {
            var TripOffers = Offer.GetTripOfferWithMoreThan(DiscountValue);

            return (TripOffers == null) ? BadRequest("Has not Trip Offers") : Ok(TripOffers);
        }
        [HttpGet]
        [Route("GetTripOfferWithlessThan")]
        public ActionResult<List<TripOfferDTO>> GetTripOfferWithlessThan(int DiscountValue)
        {
            var TripOffers = Offer.GetTripOfferWithlessThan(DiscountValue);

            return (TripOffers == null) ? BadRequest("Has not Trip Offers") : Ok(TripOffers);
        }
    }
   


}
