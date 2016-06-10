using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using TestNet.Web.Mvc5.Models;
using TestNet.Web.Mvc5.Models.Domain;
using TestNet.Web.Mvc5.Models.ViewModels;
using System;
using System.Data.Entity.Migrations;
using TestNet.Web.Mvc5.Models.Dto;

namespace TestNet.Web.Mvc5.Services
{
    public class JobService : IJobService
    {
        private readonly ApplicationDbContext _context;

        public JobService(ApplicationDbContext context)
        {
            _context = context;
            Mapper.Initialize(map =>
            {
                map.CreateMap<Job, JobDto>();
                map.CreateMap<JobInput, Job>();
            });
        }

        public void AddOrUpdate(JobInput job)
        {

            var jobLocal = _context.Jobs.FirstOrDefault(x => x.Id == job.Id);

            jobLocal = Mapper.Map(job, jobLocal);

            _context.Jobs.AddOrUpdate(jobLocal);
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

        public JobDto Get(long id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<JobDto> GetAll()
        {
            return _context.Jobs.Select(x => new JobDto()
            {
                Id = x.Id,
                Created = x.Created,
                Description = x.Description,
                EnabledDeleteComment = x.EnabledDeleteComment,
                EnabledDeleteJob = x.EnabledDeleteJob,
                EnabledEditJob = x.EnabledEditJob,
                EnabledSeeComment = x.EnabledSeeComment,
                EnabledSeeJob = x.EnabledSeeJob,
                End = x.End,
                Start = x.Start,
                State = x.State,
                Title = x.Title,
                CreatedUserId = x.CreatedUserId,
                ProjectId = x.ProjectId,
                CreatedUser = x.CreatedUser,
                AsignedUserId = x.AsignedUserId,
                AsignedUser = x.AsignedUser                                               
            });
        }

        public bool JobExists(long id)
        {
            return _context.Jobs.Any(x => x.Id == id);
        }
    }
}
