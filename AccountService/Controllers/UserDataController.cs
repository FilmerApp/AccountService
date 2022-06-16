using DAL.Interfaces;
using DAL.Model;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        private readonly IEditUserData editUserData;
        private readonly IGetUserData getUserData;

        public UserDataController(IEditUserData _editUserData, IGetUserData _getUserData)
        {
            editUserData = _editUserData;
            getUserData = _getUserData;
        }

        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Register(string username, string email, string password)
        {
            if (!getUserData.IsEmailUnique(email))
            {
                return BadRequest("Email is already in use");
            }
            User user = new (username, email, password);
            editUserData.RegisterUser(user);
            return Ok();
        }

        [HttpPost]
        [Route("ChangeUsername")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeUsername(int id, string newUsername)
        {
            try
            {
                editUserData.UpdateUsername(id, newUsername);
                return Ok();
            } 
            catch (ArgumentException)
            {
                //differentieren tussen de verschillende mogelijke argumentexceptions?
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("ChangeEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeEmail(int id, string newEmail)
        {
            try
            {
                editUserData.UpdateEmail(id, newEmail);
                return Ok();
            }
            catch (ArgumentException)
            {
                //differentieren tussen de verschillende mogelijke argumentexceptions?
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("ChangePassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangePassword(int id, string newPassword)
        {
            try
            {
                editUserData.UpdatePassword(id, newPassword);
                return Ok();
            }
            catch (ArgumentException)
            {
                //differentieren tussen de verschillende mogelijke argumentexceptions?
                return BadRequest();
            }
        }
    }
}
