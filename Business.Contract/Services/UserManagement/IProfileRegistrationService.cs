using Data.Identity.Data;
using System.Threading.Tasks;

namespace Business.Contract.Services.UserManagement
{
    public interface IProfileRegistrationService
    {
        public Task<bool> CreateProfile(AuthorisationUser user, string Name);
    }
}
