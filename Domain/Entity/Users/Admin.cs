using Domain.Entity.Base;
using System;

namespace Domain.Entity.Users
{
    public class Admin : Person
    {
        public Admin(Guid idLink): base(idLink)
        {
        }
    }
}
