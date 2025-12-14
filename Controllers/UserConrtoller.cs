using Microsoft.AspNetCore.Mvc;
using ProjectTourism.ClassDTO;
using ProjectTourism.Entities;
using ProjectTourism.Repositories;

namespace ProjectTourism.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserConrtoller : ControllerBase
    {
        private readonly IUser User;
        public UserConrtoller(IUser User)
        {
            this.User = User;

        }
        [HttpGet("GetAllUsers")]
        public ActionResult<IEnumerable<UserDTO>> GetAllUsers()
        {
            var Users = User.GetAllUsers();

            return (Users == null) ? BadRequest() : Ok(Users);
        }

        [HttpGet("FindUserBy{Id}")]
        public ActionResult<UserDTO> FindUserByID(int Id)
        {

            var UserByID = User.FindUserByID(Id);

            return UserByID != null ? Ok(UserByID) : BadRequest();

        }

        [HttpPost("AddNewUser")]
        public ActionResult<User> AddNewUser(string FirstName, string LastName, string Email, string Password)
        {

            var NewUser = new User();

           
            NewUser.FirstName = FirstName;
            NewUser.LastName = LastName;
            NewUser.Email = Email;
            NewUser.Password = Password;
            NewUser.UserId = User.AddNewUser(NewUser);

            return NewUser.UserId != 0 ?
            Ok($" YES,the User has been Added {NewUser.UserId}") :
            BadRequest($"NO,The User Has not been  Added ");

        }

        [HttpPut("UpdateUser")]
        public ActionResult<UserDTO> UpdateUser(int Id, string FirstName, string LastName, string Email, string Password)
        {

            var UpdateUser = new User();

            UpdateUser.UserId = Id;
            UpdateUser.FirstName = FirstName;
            UpdateUser.LastName = LastName;
            UpdateUser.Email = Email;
            UpdateUser.Password = Password;

            return (User.UpdateUser(UpdateUser)) ?
            Ok($" YES,the User has been Update {Id}") :
            NotFound($"NO,The User Has not been Updated");
        }

        [HttpDelete("DeleteUser{ID}")]
        public ActionResult DeleteUser(int ID)
        {
            return (User.DeleteUser(ID)) ?
            Ok($"YES,The User Has been Deleted {ID}") :
            BadRequest($"NO,The User Has not been Deleted {ID}");
        }
    }

}
