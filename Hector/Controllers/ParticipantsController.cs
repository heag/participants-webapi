using Hector.Repositories;
using Hector.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly ParticipantRepository _participantRepository;

        public ParticipantsController(ParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        // GET: api/<ParticipantsController>
        [HttpGet]
        public IActionResult GetParticipants()
        {
            return Ok(_participantRepository.GetAllParticipants());

        }

        // GET api/<ParticipantsController>/5
        [HttpGet("{id}")]
        public IActionResult GetParticipant(int id)
        {
            var participant = _participantRepository.GetParticipant(id);
            if(participant == null) {
                return NotFound();
            }

            return Ok(participant);
        }

        // POST api/<ParticipantsController>
        [HttpPost]
        public IActionResult Post([FromBody] ParticipantDTO participant)
        {
            if(participant == null)
                return BadRequest();

            var createdParticipant = _participantRepository.CreateParticipant(participant);
            Console.WriteLine(nameof(GetParticipant));
            return CreatedAtAction(nameof(GetParticipant), new { id = createdParticipant.Id }, createdParticipant);
        }

        // PUT: api/participants/5
        [HttpPut("{id}")]
        public IActionResult UpdateParticipant(int id, [FromBody] ParticipantDTO participant)
        {
            if (participant == null || participant.Id != id)
                return BadRequest();

            var updatedParticipant = _participantRepository.UpdateParticipant(id, participant);
            if (updatedParticipant == null)
                return NotFound();

            return Ok(updatedParticipant);
        }

        // DELETE: api/participants/5
        [HttpDelete("{id}")]
        public IActionResult DeleteParticipant(int id)
        {
            var success = _participantRepository.DeleteParticipant(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
