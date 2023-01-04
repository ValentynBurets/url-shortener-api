using Domain.Entity.UrlManagement;
using System;
using System.Collections.Generic;

namespace Domain.Entity.Base
{
    public class Person : EntityBase
    {
        protected Person(Guid idLink)
        {
            IdLink = idLink;
            UrlItems = new HashSet<UrlItem>();
        }

        public Guid IdLink { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UrlItem> UrlItems { get; set; }
    }
}
