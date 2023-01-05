using System;
using System.Threading.Tasks;

namespace Business.Contract.Services.UserManagement
{
    public interface IProfileManager
    {
        public Task<string> GetEmailByUserId(Guid id);
    }
}
