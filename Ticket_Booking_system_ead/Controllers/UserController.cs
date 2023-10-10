/*
* File: UserController.cs
* Author: Gawsan. R it20051402, Ananthan. Y it20249816, Yathurshan.P it20246532, Sayanthan.K it20118822
* Date: October 10, 2023
* Description: This file defines the User Controller for handling user-related actions in the Ticket Booking System backend.
*/

using Microsoft.AspNetCore.Mvc;
using Ticket_Booking_system_Backend_EAD.Models;
using Ticket_Booking_system_Backend_EAD.Services;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var user = _userServices.GetUser(id);

            if (user == null)
            {
                return NotFound($"User with Id = {id} not found");
            }

            return Ok(user);
        }

        // Custom method to validate UserType
        private bool IsValidUserType(string userType)
        {
            string[] allowedUserTypes = { "user", "traveler", "traveler agent", "backofficer" };
            return allowedUserTypes.Contains(userType, StringComparer.OrdinalIgnoreCase);
        }

        // POST api/users
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            _userServices.CreateUser(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
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
            var user = _userServices.GetUser(id);

            if (user == null)
            {
                return NotFound($"User with ID = {id} not found");
            }

            _userServices.DeleteUser(id);

            return NoContent();
        }

        // POST api/user/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] User userLogin)
        {
            // Authenticate the user based on the provided username and password.
            var authenticatedUser = _userServices.Authenticate(userLogin.Email, userLogin.Password);

            if (authenticatedUser == null)
            {
                // Return a 401 Unauthorized if authentication fails.
                return Unauthorized("Invalid email or password.");
            }

            var response = new
            {
                User = new
                {
                    authenticatedUser.Id,
                    authenticatedUser.Email,
                    authenticatedUser.UserType,
                    authenticatedUser.IsActive
                },
                Message = "Login successful" // Include a success message
            };

            return Ok(response);
            return Ok(authenticatedUser);
        }
    }
}
