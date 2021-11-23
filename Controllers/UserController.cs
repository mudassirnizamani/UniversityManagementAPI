using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementAPI.Models;

namespace UniversityManagementAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<UserModel> _userManager;

        public UserController(UserManager<UserModel> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("GetUser/{user_email}")]
        public async Task<ActionResult> GetUser(string user_email)
        {
            var user = await _userManager.FindByEmailAsync(user_email);
            Console.WriteLine(user_email);
            if (user == null)
            {
                return BadRequest(new { code = "UserDontExist", error = "User does not exist" });
            }

            return Ok(user);
        }

        // Route = /api/User/GetUserRole/
        [HttpGet]
        [Route("GetUserRole/{email}")]
        public async Task<ActionResult> GetUserRole(string email)
        {
            var appuser = await _userManager.FindByEmailAsync(email);
            try
            {
                if (appuser != null)
                {
                    var userRole = await _userManager.GetRolesAsync(appuser);

                    return Ok(new { succeeded = true, roles = userRole });
                }
                else
                {
                    return BadRequest(new { code = "EmailNotFound", error = "Email '" + email + "' was not Found" });
                }
            }
            catch (Exception)
            {
                return BadRequest(new { succeeded = false, code = "ServerError", error = "Something went wrong in the Server !" });
            }
        }

        // Route = /api/user/GetUsers/
        [HttpGet]
        [Route("GetUsers")]
        public ActionResult GetUsers()
        {
            var users = _userManager.Users;
            return Ok(users);
        }


        // Route = /api/User/GetUserById/
        [HttpGet]
        [Route("GetUserById/{id}")]
        public async Task<ActionResult> GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            return Ok(user);
        }

        // Route = /api/Users/GetUsersCount/
        // This method will return a number of total users in DataBase
        [HttpGet]
        [Route("GetUsersCount")]
        public ActionResult GetUsersCount()
        {
            try
            {
                List<UserModel> count = _userManager.Users.ToList();
                return Ok(new { count = count.Count });
            }
            catch (Exception)
            {
                return BadRequest(new { succeeded = false, code = "ServerError", error = "Something went wrong in Server !" });
            }
        }
    }
}