namespace TestNet.Web.Mvc5.Models.Domain.Relation
{
    public class TagProject:BaseModel
    {
        public long TagId { get; set; }
        public virtual Tag Tag { get; set; }

        public long ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
