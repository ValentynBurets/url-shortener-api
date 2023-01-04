using Data.Contract.Repository.UserManagement;
using Data.Contract.UnitOfWork;
using Data.EF;
using Data.Repository.UserManagement;
using System.Threading.Tasks;

namespace Data.UnitOfWork
{
    public class AuthentificationUnitOfWork : IAuthentificationUnitOfWork
    {
        private DBContext _dbContext;
        private IUserRepository _userRepository;
        private IAdminRepository _adminRepository;

        public AuthentificationUnitOfWork(DBContext domainDbContext)
        {
            _dbContext = domainDbContext;
        }
        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_dbContext);

        public IAdminRepository AdminRepository => _adminRepository ??= new AdminRepository(_dbContext);

        public async Task<int> Save() => await _dbContext.SaveChangesAsync();
    }
}
