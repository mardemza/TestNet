using AutoMapper.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNet.Web.Mvc5.Models.Domain;
using TestNet.Web.Mvc5.Models.Domain.Enum;

namespace TestNet.Web.Mvc5.Models.Dto
{
    [MapsFrom(typeof(Job))]
    public class JobDto
    {
        public JobDto()
        {
            State = StateType.OnHold;
            EnabledSeeComment = false;
            EnabledDeleteComment = false;
            EnabledSeeJob = true;
            EnabledEditJob = false;
            EnabledDeleteJob = false;
            Start = DateTime.Now;
            End = Start.AddDays(1);
        }

        #region Properties

        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public StateType State { get; set; }

        public bool EnabledSeeComment { get; set; }
        public bool EnabledDeleteComment { get; set; }
        public bool EnabledSeeJob { get; set; }
        public bool EnabledEditJob { get; set; }
        public bool EnabledDeleteJob { get; set; }


        public long ProjectId { get; set; }
        public string CreatedUserId { get; set; }
        [JsonIgnore]
        public User CreatedUser { get; set; }

        public string CreatedUserEmail
        {
            get
            {
                return CreatedUser != null ? CreatedUser.Email : "";
            }
        }

        public string AsignedUserId { get; set; }
        [JsonIgnore]
        public User AsignedUser { get; set; }

        public string AsignedUserEmail
        {
            get
            {
                return AsignedUser != null ? AsignedUser.Email : "";
            }
        }

        public DateTime Created { get; set; }

        public string StartFormated
        {
            get
            {
                return Start.ToString("dd/MM/yyyy");
            }
        }

        public string EndFormated
        {
            get
            {
                return End.ToString("dd/MM/yyyy");
            }
        }

        #endregion


    }
}
