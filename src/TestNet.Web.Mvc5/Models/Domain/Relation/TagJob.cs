namespace TestNet.Web.Mvc5.Models.Domain.Relation
{
    public class TagJob: BaseModel
    {
        public long TagId { get; set; }
        public virtual Tag Tag { get; set; }

        public long JobId { get; set; }
        public virtual Job Job { get; set; }
    }
}
