
using Microsoft.AspNetCore.Mvc;
using Ticket_Booking_system_Backend_EAD.Services;
using Ticket_Booking_system_Backend_EAD.Models;
using System;

namespace Ticket_Booking_system_Backend_EAD.Controllers
{
    [Route("api/trains")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private readonly ItrainServices _trainServices;

        public TrainController(ItrainServices trainServices)
        {
            _trainServices = trainServices;
        }

        // GET: api/trains
        [HttpGet]
        public ActionResult<List<Train>> Get()
        {
            var trains = _trainServices.GetTrains();
            return Ok(trains);
        }

        // GET api/trains/5
        [HttpGet("{id}")]
        public ActionResult<Train> Get(string id)
        {
            var train = _trainServices.GetTrain(id);

            if (train == null)
            {
                return NotFound($"Train with Id = {id} not found");
            }

            return Ok(train);
        }

        // POST api/trains
        [HttpPost]
        public ActionResult<Train> Post([FromBody] Train train)
        {
            _trainServices.CreateTrain(train);
            return CreatedAtAction(nameof(Get), new { id = train.Id }, train);
        }

        // PUT api/trains/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Train updatedTrain)
        {
            var existingTrain = _trainServices.GetTrain(id);

            if (existingTrain == null)
            {
                return NotFound($"Train with ID = {id} not found");
            }

            _trainServices.UpdateTrain(id, updatedTrain);

            return NoContent();
        }

        // DELETE api/trains/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var train = _trainServices.GetTrain(id);

            if (train == null)
            {
                return NotFound($"Train with ID = {id} not found");
            }

            _trainServices.DeleteTrain(id);

            return NoContent();
        }
    }
}
