/*
* File: ReservationController.cs
* Author: Gawsan. R it20051402, Ananthan. Y it20249816, Yathurshan.P it20246532, Sayanthan.K it20118822
* Date: October 10, 2023
* Description: This file defines the Reservation Controller for handling reservation-related actions in the Ticket Booking System backend.
*/

using Microsoft.AspNetCore.Mvc;
using Ticket_Booking_system_Backend_EAD.Models;
using Ticket_Booking_system_Backend_EAD.Services;
using System;

namespace Ticket_Booking_system_Backend_EAD.Controllers
{
    [Route("api/reservation")]
    [ApiController]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        // GET: api/reservations
        [HttpGet]
        public ActionResult<List<Reservation>> Get()
        {
            var reservations = _reservationService.GetReservations();
            return Ok(reservations);
        }

        // GET api/reservations/5
        [HttpGet("{id}")]
        public ActionResult<Reservation> Get(string id)
        {
            var reservation = _reservationService.GetReservation(id);

            if (reservation == null)
            {
                return NotFound($"Reservation with Id = {id} not found");
            }

            return Ok(reservation);
        }

        // POST api/reservations
        [HttpPost]
        public ActionResult<Reservation> Post([FromBody] Reservation reservation)
        {
<<<<<<< Updated upstream
=======
            // Check if the train exists
            var train = _trainServices.GetTrain(reservation.TrainID);
            if (train == null)
            {
                return NotFound($"Train with ID = {reservation.TrainID} not found");
            }

            // Check if the user exists
            var user = _userServices.GetUser(reservation.UserID);
            if (user == null)
            {
                return NotFound($"User with ID = {reservation.UserID} not found");
            }

            // Calculate the difference between the reservation date and the current date
            var currentDate = DateTime.UtcNow;
            var reservationDate = reservation.ReservationDate;
            var timeUntilReservation = reservationDate - currentDate;

            // Check if the reservation date is within 30 days from the booking date
            if (timeUntilReservation.TotalDays > 30)
            {
                return BadRequest("Reservation date must be within 30 days from the booking date.");
            }

            // Check if the user is a Traveler and has 4 or more reservations
            if (user.UserType.Equals("user", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("User does not have access.");
            }

            // Check if the user is a Traveler and has 4 or more reservations
            if (user.UserType.Equals("Traveler", StringComparison.OrdinalIgnoreCase))
            {
                var userReservations = _reservationService.GetReservationsByUserID(reservation.UserID);
                if (userReservations.Count >= 4)
                {
                    return BadRequest("Traveler cannot have more than 4 reservations.");
                }
            }

>>>>>>> Stashed changes
            _reservationService.CreateReservation(reservation);
            return CreatedAtAction(nameof(Get), new { id = reservation.Id }, reservation);
        }

        // PUT api/reservations/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Reservation updatedReservation)
        {
            var existingReservation = _reservationService.GetReservation(id);

            if (existingReservation == null)
            {
                return NotFound($"Reservation with ID = {id} not found");
            }

            _reservationService.UpdateReservation(id, updatedReservation);

            return NoContent();
        }

        // DELETE api/reservations/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var reservation = _reservationService.GetReservation(id);

            if (reservation == null)
            {
                return NotFound($"Reservation with ID = {id} not found");
            }

            _reservationService.DeleteReservation(id);

            return NoContent();
        }
    }
}
