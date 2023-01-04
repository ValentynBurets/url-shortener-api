using Data.Contract.Repository.UrlItemManagement;
using Data.Contract.Repository.UserManagement;
using Data.Contract.UnitOfWork.Base;

namespace Data.Contract.UnitOfWork
{
    public interface IUnitOfWork : IUnitOfWorkBase
    {
        IUrlItemRepository UrlItemRepository { get; }
        IUserRepository UserRepository { get; }
        IAdminRepository AdminRepository { get; }
    }
}
