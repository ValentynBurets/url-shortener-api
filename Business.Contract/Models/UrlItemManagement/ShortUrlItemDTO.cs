using System;

namespace Business.Contract.Models.UrlItemManagement
{
    public class ShortUrlItemDTO
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public string ShortUrl { get; set; }
    }
}
