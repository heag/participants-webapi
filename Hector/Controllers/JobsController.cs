using Microsoft.AspNetCore.Mvc;
using Hector.Models.DTOs;
using Hector.Repositories;

namespace Hector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly JobRepository _jobRepository;

        public JobsController(JobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        // GET: api/<JobsController>
        [HttpGet]
        public IActionResult GetJobs(int? count)
        {
            return Ok(count.HasValue ? _jobRepository.GetJobs((int)count) : _jobRepository.GetAllJobs());
        }

        // GET api/<JobsController>/5
        [HttpGet("{id}")]
        public IActionResult GetJob(string id)
        {
            var job = _jobRepository.GetJob(id);
            if (job == null)
            {
                return NotFound();
            }

            return Ok(job);
        }

        // POST api/<JobsController>
        [HttpPost]
        public IActionResult Post([FromBody] JobDTO job)
        {
            if (job == null)
                return BadRequest();

            var createdJob = _jobRepository.CreateJob(job);
            Console.WriteLine(nameof(GetJob));
            return CreatedAtAction(nameof(GetJob), new { id = createdJob.Id }, createdJob);
        }

        // PUT api/<JobsController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateJob(string id, [FromBody] JobDTO job)
        {
            if (job == null || job.Id != id)
                return BadRequest();

            var updatedJob = _jobRepository.UpdateJob(id, job);
            if (updatedJob == null)
                return NotFound();

            return Ok(updatedJob);
        }

        // DELETE api/<JobsController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteJob(string id)
        {
            var success = _jobRepository.DeleteJob(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
