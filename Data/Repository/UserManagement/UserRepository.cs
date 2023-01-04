using Data.Contract.Repository.UserManagement;
using Data.EF;
using Data.Repository.Base;
using Domain.Entity.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.UserManagement
{
    public class UserRepository : EntityRepository<User>, IUserRepository
    {
        public UserRepository(DBContext dbContext) : base(dbContext)
        {
        }

        public async Task<Guid> GeIdLinkById(Guid id)
        {
            return (await _DbContext.Users.Where(u => u.Id == id).FirstAsync()).Id;
        }

        public async Task<User> GetByIdLink(Guid idLink)
        {
            return await _DbContext.Users.FirstAsync(e => e.IdLink == idLink);
        }
    }
}
