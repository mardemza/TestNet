using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestNet.Web.Models.Domain;
using TestNet.Web.Models.ViewModels;

namespace TestNet.Web.Services
{
    public interface IJobService
    {
        IEnumerable<Job> GetAll();
        void AddOrUpdate(JobInput job);
        void Delete(long id);
        bool JobExists(long id);
    }
}
