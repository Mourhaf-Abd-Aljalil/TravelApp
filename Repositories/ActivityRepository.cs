using ProjectTourism.ClassDTO;
using ProjectTourism.Data;
using ProjectTourism.Entities;

namespace ProjectTourism.Repositories
{
    public class ActivityRepository : IActivity
    {

        
        public IEnumerable<ActivityDTO> GetAllActivities()
        {
            var context = new AppDbContext();

            var Activitys = context.Activities.
                        Select(Activity => new ActivityDTO
                        {
                            ActivityId = Activity.ActivityId,
                            ActivityName = Activity.ActivityName,
                            Description = Activity.Description,
                            Location = Activity.Location,
                            TripId = Activity.TripId,
                        
                        }).ToList();

            return Activitys;
        }
        public Activity FindActivityByID(int Id)
        {
            var context = new AppDbContext();

            var Activity = context.Activities.Find(Id);

            return Activity;
        }
        public List<TripActivityDTO> TripActivities()
        {
            var context = new AppDbContext();

            var TripActivities = context.Trips.Join(context.Activities,r => r.TripId,Ac => Ac.TripId,
                (r,Ac) => new TripActivityDTO
                {
                    TripName = r.Title ,
                    ActivityName = Ac.ActivityName,
                    Description = Ac.Description,
                    Location = Ac.Location,

                }).ToList();

            return TripActivities;
        }
    }

}
