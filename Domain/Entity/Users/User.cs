using Domain.Entity.Base;
using System;

namespace Domain.Entity.Users
{
    public class User : Person
    {
        public User(Guid idLink) : base(idLink)
        {
        }
    }
}
