using Microsoft.AspNetCore.Mvc;
using Ticket_Booking_system_Backend_EAD.Models;
using Ticket_Booking_system_Backend_EAD.Services;

namespace Ticket_Booking_system_Backend_EAD.Controllers
{
    [Route("api/reservation")]
    [ApiController]
    public class ReservationController: Controller
    {
        private readonly IReservationService _reservationService;
        private readonly ItrainServices _trainServices;
        private readonly IUserServices _userServices;

        public ReservationController(IReservationService reservationService, ItrainServices trainServices, IUserServices userServices)
        {
            _reservationService = reservationService;
            _trainServices = trainServices;
            _userServices = userServices;
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

        // GET api/reservations/5
        [HttpGet("/bookings/train/{id}")]
        public ActionResult<Reservation> GetByTrainID(string id)
        {
            var reservation = _reservationService.GetReservationsByTrainID(id);

            if (reservation == null)
            {
                return NotFound($"Reservation with TrainId = {id} not found");
            }

            return Ok(reservation);
        }

        [HttpGet("/bookings/user/{id}")]
        public ActionResult<Reservation> GetByUserID(string id)
        {
            var reservation = _reservationService.GetReservationsByUserID(id);

            if (reservation == null)
            {
                return NotFound($"Reservation with UserId = {id} not found");
            }

            return Ok(reservation);
        }

        // POST api/reservations
        [HttpPost]
        public ActionResult<Reservation> Post([FromBody] Reservation reservation)
        {
            // Check if the train exists
            var train = _trainServices.GetTrain(reservation.TrainID);
            if (train == null)
            {
                return NotFound($"Train with ID = {reservation.TrainID} not found");
            }

            // Check if the user exists
            var user = _userServices.GetUser(reservation.UserID);
            var userNic = _userServices.GetUserByNIC(reservation.NIC);
            if (user == null)
            {
                return NotFound($"User with ID = {reservation.UserID} not found");
            }

            if (userNic == null)
            {
                return NotFound($"User with NIC = {reservation.NIC} not found");
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

            // Calculate the difference between the current date and the reservation date
            var currentDate = DateTime.UtcNow;
            var reservationDate = existingReservation.ReservationDate; // Assuming ReservationDate is of type DateTime
            var timeUntilReservation = reservationDate - currentDate;

            // Check if the reservation can be updated (at least 5 days before)
            if (timeUntilReservation.TotalDays <= 5)
            {
                return BadRequest("Reservation can only be updated at least 5 days before the reservation date.");
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

            // Calculate the difference between the current date and the reservation date
            var currentDate = DateTime.UtcNow;
            var reservationDate = reservation.ReservationDate; // Assuming ReservationDate is of type DateTime
            var timeUntilReservation = reservationDate - currentDate;

            // Check if the reservation can be updated (at least 5 days before)
            if (timeUntilReservation.TotalDays <= 5)
            {
                return BadRequest("Reservation can only be updated at least 5 days before the reservation date.");
            }

            _reservationService.DeleteReservation(id);

            return NoContent();
        }
    }
}
