using ProjectTourism.ClassDTO;
using ProjectTourism.Entities;

namespace ProjectTourism.Repositories
{
    public interface IActivity
    {
        IEnumerable<ActivityDTO> GetAllActivities();
        Activity FindActivityByID(int Id);
        List<TripActivityDTO> TripActivities();
    }
}
