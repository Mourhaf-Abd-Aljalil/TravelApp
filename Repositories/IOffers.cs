using ProjectTourism.ClassDTO;
using ProjectTourism.Entities;

namespace ProjectTourism.Repositories
{
    public interface IOffers
    {
        IEnumerable<OffersDTO> GetAllOffers();
        Offer FindOfferByID(int Id);
        List<TripOfferDTO> GetTripOffer();
        List<TripOfferDTO> GetTripOfferWithMoreThan(int DiscountValue);
        
            List<TripOfferDTO> GetTripOfferWithlessThan(int DiscountValue);
    }
}
