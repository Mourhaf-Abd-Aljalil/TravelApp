using ProjectTourism.ClassDTO;
using ProjectTourism.Data;
using ProjectTourism.Entities;

namespace ProjectTourism.Repositories
{
    public class OffersRepository : IOffers
    {
        public IEnumerable<OffersDTO> GetAllOffers()
        {
            var context = new AppDbContext();

        var Offers = context.Offers.
                        Select(Offer => new OffersDTO
                        {
                       OfferId = Offer.OfferId,
                       Title = Offer.Title,
                       Description = Offer.Description,
                       DiscountValue = Offer.DiscountValue,
                       TripId = Offer.TripId,

                        }).ToList();

            return Offers;
        }
        public Offer FindOfferByID(int Id)
        {
            var context = new AppDbContext();

            var Offer = context.Offers.Find(Id);

            return Offer;
        }
        public List<TripOfferDTO> GetTripOffer() { 
        var context = new AppDbContext();

            var TripOffer = context.Trips.Join(context.Offers, T => T.TripId, O => O.TripId,
                (T, O) => new TripOfferDTO
                {
                    TripName = T.Title,
                    OfferName = O.Title,
                    Description = O.Description,
                    DiscountValue = O.DiscountValue,
                }).ToList();

            return TripOffer;
        }
        public List<TripOfferDTO> GetTripOfferWithMoreThan(int DiscountValue)
        {
            var context = new AppDbContext();

            var TripOffer = context.Trips.Join(context.Offers, T => T.TripId, O => O.TripId,
                (T, O) => new TripOfferDTO
                {
                    TripName = T.Title,
                    OfferName = O.Title,
                    Description = O.Description,
                    DiscountValue = O.DiscountValue,
                }).Where(T => T.DiscountValue >= DiscountValue).ToList();

            return TripOffer;
        }
        
             public List<TripOfferDTO> GetTripOfferWithlessThan(int DiscountValue)
        {
            var context = new AppDbContext();

            var TripOffer = context.Trips.Join(context.Offers, T => T.TripId, O => O.TripId,
                (T, O) => new TripOfferDTO
                {
                    TripName = T.Title,
                    OfferName = O.Title,
                    Description = O.Description,
                    DiscountValue = O.DiscountValue,
                }).Where(T => T.DiscountValue <= DiscountValue).ToList();

            return TripOffer;
        }
    }

}
