namespace TestNet.Web.Mvc5.Models.Domain
{
    public class Comment : BaseModel
    {
        #region Properties

        public string Body { get; set; }

        public string CreatedUserId { get; set; }        
        public virtual User CreatedUser { get; set; }

        public long JobId { get; set; }        
        public virtual Job Job { get; set; }

        #endregion
    }
}
