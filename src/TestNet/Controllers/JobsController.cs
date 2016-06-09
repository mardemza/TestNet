using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestNet.Web.Models.Domain;
using TestNet.Web.Services;
using TestNet.Web.Models.ViewModels;

namespace TestNet.Controllers
{
    [Produces("application/json")]
    [Route("api/Jobs")]
    public class JobsController : Controller
    {        
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        // GET: api/Jobs
        [HttpGet]
        public IEnumerable<Job> GetJobs()
        {
            return _jobService.GetAll();
        }

        // GET: api/Jobs/5
        [HttpGet("{id}")]
        public IActionResult GetJob([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Job job = _jobService.GetAll().FirstOrDefault(m => m.Id == id);

            if (job == null)
            {
                return NotFound();
            }

            return Ok(job);
        }

        // PUT: api/Jobs/5
        [HttpPut("{id}")]
        public IActionResult PutJob([FromRoute] long id, [FromBody] JobInput job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != job.Id)
            {
                return BadRequest();
            }

            _jobService.AddOrUpdate(job);
            return NoContent();
        }

        // POST: api/Jobs
        [HttpPost]
        public IActionResult PostJob([FromBody] JobInput job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_jobService.JobExists(job.Id))
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }

            _jobService.AddOrUpdate(job);

            return CreatedAtAction("GetJob", new { id = job.Id }, job);
        }

        // DELETE: api/Jobs/5
        [HttpDelete("{id}")]
        public IActionResult DeleteJob([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _jobService.Delete(id);

            return Ok(id);
        }        
    }
}