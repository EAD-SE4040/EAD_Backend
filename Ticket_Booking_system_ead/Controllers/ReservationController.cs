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
