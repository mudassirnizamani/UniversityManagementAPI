using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementAPI.Models;
using UniversityManagementAPI.ViewModels;

namespace UniversityManagementAPI.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<UserModel> _userManager;
    private RoleManager<IdentityRole> _roleManager;

    public AuthController(UserManager<UserModel> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    // Creating User
    [Route("Signup")]
    [HttpPost]
    public async Task<ActionResult> Signup(SignupViewModel model)
    {
        string currentDate = DateTime.Now.ToString("d/M/yyyy");
        var user = new UserModel()
        {
            CreatedAt = currentDate,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            ProfilePic = model.ProfilePic,
            UserName = model.Email
        };

        try
        {
            var result = await _userManager.CreateAsync(user, model.Password);

            IdentityRole role = new IdentityRole()
            {
                Name = model.Role
            };
            if (result.Succeeded)
            {
                await _roleManager.CreateAsync(role);
                await _userManager.AddToRoleAsync(user, model.Role);
                return Ok(result);
            }

            return BadRequest(result);
        }
        catch (Exception)
        {
            return BadRequest(new { code = "ServerError", error = "Something went wrong in the server" });
        }
    }


    // Authenticating User
    // Route = /api/Auth/Signin
    [HttpPost]
    [Route("Signin")]
    public async Task<ActionResult> Signin(SigninViewModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        var password = await _userManager.CheckPasswordAsync(user, model.Password);
        try
        {
            if (user is null)
            {
                return BadRequest(new { succeeded = false, code = "EmailNotFound", error = "Email '" + model.Email + "' was not Found" });
            }
            else if (user is not null && !password)
            {
                return BadRequest(new { succeeded = false, code = "IncorrectPassword", error = "Incorrect Password for '" + model.Email + "'" });
            }
            else if (user is not null && password)
            {
                var role = await _userManager.GetRolesAsync(user);
                return Ok(new { user = user, role = role });
            }
            else
            {
                return BadRequest(new { succeeded = false, code = "InvalidCredentials", error = "Email or Password in Incorrect" });
            }
        }
        catch (Exception)
        {
            return BadRequest(new { succeeded = false, code = "ServerError", error = "Something went wrong in the Server !" });
        }
    }

}
