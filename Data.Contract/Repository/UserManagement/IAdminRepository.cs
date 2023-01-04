using Data.Contract.Repository.Base;
using Domain.Entity.Users;
using System;
using System.Threading.Tasks;

namespace Data.Contract.Repository.UserManagement
{
    public interface IAdminRepository : IEntityRepository<Admin>
    {
        public Task<Admin> GetByIdLink(Guid idLink);
    }
}
