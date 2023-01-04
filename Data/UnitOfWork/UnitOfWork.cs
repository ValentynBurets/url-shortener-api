using Data.Contract.Repository.UrlItemManagement;
using Data.Contract.Repository.UserManagement;
using Data.Contract.UnitOfWork;
using Data.EF;
using Data.Repository.UrlManagement;
using Data.Repository.UserManagement;
using System.Threading.Tasks;

namespace Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContext _dbContext;

        private IUrlItemRepository _urlItemRepository;

        private IUserRepository _userRepository;
        private IAdminRepository _adminRepository;

        public UnitOfWork(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUrlItemRepository UrlItemRepository => _urlItemRepository ??= new UrlItemRepository(_dbContext);
        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_dbContext);
        public IAdminRepository AdminRepository => _adminRepository ??= new AdminRepository(_dbContext);

        public async Task<int> Save() => await _dbContext.SaveChangesAsync();
    }
}
