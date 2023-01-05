using System;
using System.Linq;
using System.Threading.Tasks;
using Data.Contract.Repository.UrlItemManagement;
using Data.EF;
using Data.Repository.Base;
using Domain.Entity.UrlManagement;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.UrlManagement
{
    internal class UrlItemRepository : EntityRepository<UrlItem>, IUrlItemRepository
    {
        public UrlItemRepository(DBContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsExist(string Url)
        {
            var item = await _DbContext.UrlItems.Where(u => u.Url == Url).FirstOrDefaultAsync(); 
            return item != null ? true : false;
        }

        public async Task<Guid> GetIdByUrl(string Url)
        {
            return (await _DbContext.UrlItems.Where(u => u.Url == Url).FirstAsync()).Id;
        }
    }
}
