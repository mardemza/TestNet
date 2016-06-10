using System.Collections.Generic;
using TestNet.Web.Mvc5.Models.Domain;
using TestNet.Web.Mvc5.Models.Dto;
using TestNet.Web.Mvc5.Models.ViewModels;

namespace TestNet.Web.Mvc5.Services
{
    public interface IJobService
    {
        IEnumerable<JobDto> GetAll();
        void AddOrUpdate(JobInput job);
        void Delete(long id);
        bool JobExists(long id);
        JobDto Get(long id);
    }
}
