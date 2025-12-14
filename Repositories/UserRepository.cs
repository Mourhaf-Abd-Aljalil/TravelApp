using ProjectTourism.ClassDTO;
using ProjectTourism.Data;
using ProjectTourism.Entities;


namespace ProjectTourism.Repositories
{
    public class UserRepository : IUser
    {


        public IEnumerable<UserDTO> GetAllUsers()
        {
            var context = new AppDbContext();

            var Users = context.Users?.
                        Select(User => new UserDTO
                        {
                            UserId = User.UserId,
                            FirstName = User.FirstName,
                            LastName = User.LastName,
                            Email = User.Email,
                            Password = User.Password,
                            
                        }).ToList();

            return Users;
        }
        public List<UserDTO> FindUserByID(int Id)
        {
            var context = new AppDbContext();

            var User = context.Users?.Where(User => User.UserId == Id).
                Select(User => new UserDTO
                {
                    UserId = User.UserId,
                    FirstName = User.FirstName,
                    LastName = User.LastName,
                    Email = User.Email,
                    Password = User.Password,
                }).ToList();

            return User;
        }
        public int AddNewUser(User NewUser)
        {
            var context = new AppDbContext();

            int Id = 0;


            try
            {
                context.Users?.Add(NewUser);
                context.SaveChanges();
                Id = NewUser.UserId;
            }
            catch (Exception e)
            {
                Id = 0;
            }

            return Id;
        }
        public bool UpdateUser(User User)
        {
            var context = new AppDbContext();

            bool IsUpdate = false;

            try
            {
                context.Users?.Update(User);
                context.SaveChanges();
                IsUpdate = true;
            }
            catch (Exception e)
            {
                IsUpdate = false;
            }

            return IsUpdate;
        }
        public bool DeleteUser(int ID)
        {
            var context = new AppDbContext();

            var User = context.Users?.Find(ID);

            bool IsDeleted = false;
            try
            {
                if (User != null)
                {
                    context.Users?.Remove(User);
                    context.SaveChanges();
                    IsDeleted = true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                IsDeleted = false;
            }

            return IsDeleted;
        }

    }
}
