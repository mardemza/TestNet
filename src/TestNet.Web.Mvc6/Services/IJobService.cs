using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestNet.Web.Mvc6.Models.Domain;
using TestNet.Web.Mvc6.Models.ViewModels;

namespace TestNet.Web.Mvc6.Services
{
    public interface IJobService
    {
        IEnumerable<Job> GetAll();
        void AddOrUpdate(JobInput job);
        void Delete(long id);
        bool JobExists(long id);
    }
}
