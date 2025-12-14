using Microsoft.AspNetCore.Mvc;
using ProjectTourism.ClassDTO;
using ProjectTourism.Repositories;

namespace ProjectTourism.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AttractionConrtoller : ControllerBase
    {
        private readonly IAttraction Attraction;
        public AttractionConrtoller(IAttraction Attraction)
        {
            this.Attraction = Attraction;

        }
        [HttpGet("GetAllAttractions")]
        public ActionResult<IEnumerable<AttractionDTO>> GetAllAttractions()
        {
            var Attractions = Attraction.GetAllAttractions();

            return (Attractions == null) ? BadRequest() : Ok(Attractions);
        }

        [HttpGet("FindAttractionBy{Id}")]
        public ActionResult<AttractionDTO> FindAttractionByID(int Id)
        {

            var AttractionByID = Attraction.FindAttractionByID(Id);

            return AttractionByID != null ? Ok(AttractionByID) : BadRequest();

        }
        [HttpGet]
        [Route("GetTripAttractions")]
        public ActionResult<List<TripAttractionDTO>> GetTripAttractions()
        {
            var TripAttraction = Attraction.GetTripAttractions();

            return (TripAttraction == null) ? BadRequest("There are no tourist Attraction available for these trips") : Ok(TripAttraction);
        }
    }
   


}
