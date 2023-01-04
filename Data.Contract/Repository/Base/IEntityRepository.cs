using Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contract.Repository.Base
{
    public interface IEntityRepository<TEntity>
        where TEntity : EntityBase
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> expression);
        Task<Guid> Add(TEntity entity);
        Task Remove(TEntity entity);
    }
}
