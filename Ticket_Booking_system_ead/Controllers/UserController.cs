//using Microsoft.AspNetCore.Mvc;
//using Ticket_Booking_system_Backend_EAD.Models;
//using Ticket_Booking_system_Backend_EAD.Services;



//namespace Ticket_Booking_system_Backend_EAD.Controllers
//{
//    [Route("api/user")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        private readonly IUserServices userServices;
//        public UserController(IUserServices userServices)
//        {
//            this.userServices = userServices;
//        }
//        // GET: api/<UserController>
//        [HttpGet]
//        public ActionResult<User> Post([FromBody] User user)
//        {
//            userServices.CreateUser(user);
//            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
//        }

//        public ActionResult<User> Get(String id)
//        {
//            var user = userServices.GetUser(id);

//            if (user == null)
//            {
//                return NotFound($"Students with Id = {id} not found ");

//            }
//            return user;
//        }

//    }
//}


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

        // POST: api/user
        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            _userServices.CreateUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // GET: api/user/{id}
        [HttpGet("{id}")]
        public IActionResult GetUser(string id)
        {
            var user = _userServices.GetUser(id);

            if (user == null)
            {
                return NotFound($"User with Id = {id} not found");
            }

            return Ok(user);
        }
    }
}

