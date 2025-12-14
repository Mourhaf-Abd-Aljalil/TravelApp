using ProjectTourism.ClassDTO;
using ProjectTourism.Entities;

namespace ProjectTourism.Repositories
{
    public interface IUser
    {
        IEnumerable<UserDTO> GetAllUsers();
        List<UserDTO> FindUserByID(int Id);
        int AddNewUser(User NewUser);
        bool UpdateUser(User User);
        bool DeleteUser(int Id);
    }
}
