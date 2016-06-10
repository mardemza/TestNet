using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TestNet.Web.Mvc5.Models.Domain;
using TestNet.Web.Mvc5.Models.Dto;
using TestNet.Web.Mvc5.Models.ViewModels;
using TestNet.Web.Mvc5.Services;

namespace TestNet.Web.Mvc5.Controllers
{
    [Authorize]
    public class JobsController : ApiController
    {
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;

        }

        // GET api/jobs
        public IEnumerable<JobDto> Get(long? projectId)
        {   
            return projectId.HasValue ? _jobService.GetAll().Where(x => x.ProjectId == projectId.Value): _jobService.GetAll();
        }

        // GET api/jobs/5
        public JobDto Get(long id)
        {
            return _jobService.Get(id);
        }

        // POST api/jobs
        public void Post([FromBody]JobInput job)
        {
            _jobService.AddOrUpdate(job);
        }

        // PUT api/job/5
        public void Put(long id, [FromBody]JobInput job)
        {
            if (_jobService.JobExists(id))
                _jobService.AddOrUpdate(job);
        }

        // DELETE api/jobs/5
        public void Delete(long id)
        {
            _jobService.Delete(id);
        }
    }
}