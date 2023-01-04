using Data.Contract.Repository.Base;
using Domain.Entity.Users;
using System;
using System.Threading.Tasks;

namespace Data.Contract.Repository.UserManagement
{
    public interface IUserRepository : IEntityRepository<User>
    {
        public Task<User> GetByIdLink(Guid idLink);
        public Task<Guid> GeIdLinkById(Guid id);
    }
}
