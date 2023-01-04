using Data.Contract.Repository.UserManagement;
using Data.EF;
using Data.Repository.Base;
using Domain.Entity.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Data.Repository.UserManagement
{
    public class AdminRepository : EntityRepository<Admin>, IAdminRepository
    {
        public AdminRepository(DBContext dbContext) : base(dbContext)
        {

        }

        public async Task<Admin> GetByIdLink(Guid idLink)
        {
            return await _DbContext.Admins.FirstAsync(e => e.IdLink == idLink);
        }
    }
}
