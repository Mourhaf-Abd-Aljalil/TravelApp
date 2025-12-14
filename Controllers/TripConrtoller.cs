using Microsoft.AspNetCore.Mvc;
using ProjectTourism.ClassDTO;
using ProjectTourism.Data;
using ProjectTourism.Entities;
using ProjectTourism.Repositories;

namespace ProjectTourism.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TripConrtoller : ControllerBase
    {
        private readonly ITrip Trip;
        public TripConrtoller(ITrip Trip)
        {
            this.Trip = Trip;
            
        }
        [HttpGet("GetAllTrips")]
            public ActionResult<IEnumerable<TripDTO>> GetAllTrips()
            {
            var Trips = Trip.GetAllTrips();
                
            return (Trips == null) ? BadRequest() : Ok(Trips); 
        }

        [HttpGet("FindTripBy{Id}")]
        public ActionResult<TripDTO> FindTripByID(int Id)
        {

            var TripByID = Trip.FindTripByID(Id);

            return TripByID != null ? Ok(TripByID) : BadRequest();
               
        }

        [HttpPost("AddNewTrip")]
        public ActionResult<Trip> AddNewTrip( string Title, string Description, DateTime StartDate, DateTime EndDate, decimal Price)
        {

            var NewTrip = new Trip();

            NewTrip.Title = Title;
            NewTrip.Description = Description;
            NewTrip.StartDate = StartDate;
            NewTrip.EndDate = EndDate;
            NewTrip.Price = Price;
            NewTrip.TripId = Trip.AddNewTrip(NewTrip);

            return NewTrip.TripId != 0 ? 
            Ok($" YES,the Trip has been Added {NewTrip.TripId}") :
            BadRequest($"NO,The Trip Has not been  Added ");
              
        }

        [HttpPut("UpdateTrip")]
        public ActionResult<TripDTO> UpdateTrip(int Id, string Title, string Description, DateTime StartDate, DateTime EndDate, decimal Price)
        {

                var UpdateTrip = new Trip();
           
                UpdateTrip.TripId = Id;
                UpdateTrip.Title = Title;
                UpdateTrip.Description = Description;
                UpdateTrip.StartDate = StartDate;
                UpdateTrip.EndDate = EndDate;
                UpdateTrip.Price = Price;

                return (Trip.UpdateTrip(UpdateTrip)) ? 
                Ok($" YES,the Trip has been Update {Id}") : 
                NotFound($"NO,The Trip Has not been Updated");
        }

        [HttpDelete("DeleteTrip{ID}")]
        public ActionResult DeleteTrip(int ID)
        {
                return (Trip.DeleteTrip(ID)) ?
                Ok($"YES,The Trip Has been Deleted {ID}") :
                BadRequest($"NO,The Trip Has not been Deleted {ID}");
        }
    }
    
}
