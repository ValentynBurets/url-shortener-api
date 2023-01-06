using System;

namespace Business.Contract.Models.UrlItemManagement
{
    public class UrlItemDTO
    {
        public Guid Id { get; set; }
        public Guid CreatorId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Url { get; set; }
        public string ShortUrl { get; set; }
    }
}
