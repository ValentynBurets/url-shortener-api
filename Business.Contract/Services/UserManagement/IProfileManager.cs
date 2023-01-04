using System;
using System.Threading.Tasks;

namespace Business.Contract.Services.UserManagement
{
    public interface IProfileManager
    {
        public Task<string> GetNameByUserId(Guid id);
    }
}
