using System.Threading.Tasks;

namespace Data.Contract.UnitOfWork.Base
{
    public interface IUnitOfWorkBase
    {
        Task<int> Save();
    }
}
