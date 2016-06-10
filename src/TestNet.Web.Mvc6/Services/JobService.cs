using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestNet.Web.Mvc6.Data;
using TestNet.Web.Mvc6.Models.Domain;
using TestNet.Web.Mvc6.Models.ViewModels;

namespace TestNet.Web.Mvc6.Services
{
    public class JobService : IJobService
    {
        private readonly ApplicationDbContext _context;


        public JobService(ApplicationDbContext context)
        {
            _context = context;
            Mapper.Initialize(map => { map.CreateMap<JobInput, Job>(); });
        }

        public void AddOrUpdate(JobInput job)
        {

            var jobLocal = _context.Jobs.FirstOrDefault(x => x.Id == job.Id);

            var add = jobLocal == null;
            jobLocal = Mapper.Map(job, jobLocal);

            if (add)
            {
                _context.Jobs.Add(jobLocal);
            }
            else
            {
                _context.Jobs.Update(jobLocal);
            }
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var job = _context.Jobs.FirstOrDefault(x => x.Id == id);
            if (job != null)
            {
                _context.Jobs.Remove(job);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Job> GetAll()
        {
            return _context.Jobs;
        }

        public bool JobExists(long id)
        {
            return _context.Jobs.Any(x => x.Id == id);
        }
    }
}
