using System;
using TestNet.Web.Models.Domain.Enum;

namespace TestNet.Web.Models.ViewModels
{

    public class JobInput
    {
        public JobInput()
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
        public string AsignedUserId { get; set; }      

        #endregion
        
    }
}
