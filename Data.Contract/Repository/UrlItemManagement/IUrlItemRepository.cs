using System;
using Data.Contract.Repository.Base;
using Domain.Entity.UrlManagement;
using System.Threading.Tasks;

namespace Data.Contract.Repository.UrlItemManagement
{
    public interface IUrlItemRepository: IEntityRepository<UrlItem>
    {
        public Task<bool> IsExist(string Url);
        public Task<Guid> GetIdByUrl(string Url);
    }
}
