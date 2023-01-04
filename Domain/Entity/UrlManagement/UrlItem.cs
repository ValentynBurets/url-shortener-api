using Domain.Entity.Base;
using System;

namespace Domain.Entity.UrlManagement
{
    public class UrlItem: EntityBase
    {
        public Guid CreatorId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Url { get; set; }
        public string ShortUrl { get; set; }
        public virtual Person Creator { get; set; }
    }
}
