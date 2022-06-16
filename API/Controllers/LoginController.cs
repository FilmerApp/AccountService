using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL.Interfaces;
using DAL.Model;

namespace AccountService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IGetUserData getUserData;

        public LoginController(IGetUserData _getUserData)
        {
            getUserData = _getUserData;
        }

        [HttpGet]
        [Route("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Login(string email, string password)
        {
            if (email == null || password == null)
            {
                return BadRequest("No valid email and/or password were provided");
            }

            try
            {
                User user = getUserData.GetUserByEmail(password);
                if (user.Password == password)
                {
                    return Ok();
                }
                else
                {
                    return Unauthorized("Password is incorrect");
                }
            } 
            catch (ArgumentException)
            {
                return BadRequest("No user with this email could be found");
            }
        }
    }
}
