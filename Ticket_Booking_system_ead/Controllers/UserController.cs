using Microsoft.AspNetCore.Mvc;
using Ticket_Booking_system_Backend_EAD.Models;
using Ticket_Booking_system_Backend_EAD.Services;
using System;

namespace Ticket_Booking_system_Backend_EAD.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        // GET: api/users
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            var users = _userServices.GetUsers();
            return Ok(users);
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(string id)
        {
            var User = _userServices.GetUser(id);

            if (User == null)
            {
                return NotFound($"User with Id = {id} not found");
            }

            return Ok(User);
        }

        // POST api/users
        [HttpPost]
        public ActionResult<User> Post([FromBody] User User)
        {
            _userServices.CreateUser(User);
            return CreatedAtAction(nameof(Get), new { id = User.Id }, User);
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] User updatedUser)
        {
            var existingUser = _userServices.GetUser(id);

            if (existingUser == null)
            {
                return NotFound($"User with ID = {id} not found");
            }

            _userServices.UpdateUser(id, updatedUser);

            return NoContent();
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var User = _userServices.GetUser(id);

            if (User == null)
            {
                return NotFound($"User with ID = {id} not found");
            }

            _userServices.DeleteUser(id);

            return NoContent();
        }
    }
}

