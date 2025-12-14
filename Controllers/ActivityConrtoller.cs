using Microsoft.AspNetCore.Mvc;
using ProjectTourism.ClassDTO;
using ProjectTourism.Repositories;
using System.Collections.Generic;

namespace ProjectTourism.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivityConrtoller : ControllerBase
    {
        private readonly IActivity Activity;
        public ActivityConrtoller(IActivity Activity)
        {
            this.Activity = Activity;

        }
        [HttpGet("GetAllActivitys")]
        public ActionResult<IEnumerable<ActivityDTO>> GetAllActivities()
        {
            var Activitys = Activity.GetAllActivities();

            return (Activitys == null) ? BadRequest() : Ok(Activitys);
        }

        [HttpGet("FindActivityBy{Id}")]
        public ActionResult<ActivityDTO> FindActivityByID(int Id)
        {

            var ActivityByID = Activity.FindActivityByID(Id);

            return ActivityByID != null ? Ok(ActivityByID) : BadRequest();

        }
        [HttpGet]
        [Route("GetTripActivities")]
        public ActionResult<List<TripActivityDTO>> GetTripActivities()
        {
            List<TripActivityDTO> Trip = Activity.TripActivities();

                return (Trip == null) ?BadRequest("Is Not found Trip Activities"):
                Ok(Trip);
        }

    }



}
