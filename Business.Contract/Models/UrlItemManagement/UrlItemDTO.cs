using System;
using Business.Contract.Models.UserManagement;
using Domain.Entity.Base;

namespace Business.Contract.Models.UrlItemManagement
{
    public class UrlItemDTO
    {
        public Guid Id { get; set; }
        public PersonDTO Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Url { get; set; }
        public string ShortUrl { get; set; }
    }
}
