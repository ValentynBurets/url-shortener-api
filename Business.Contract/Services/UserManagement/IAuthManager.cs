using Business.Contract.Models.UserManagement;
using System.Threading.Tasks;

namespace Business.Contract.Services.UserManagement
{
    public interface IAuthManager
    {
        Task<string> CreateToken();
        Task<bool> ValidateUser(PersonDTO userModel);
    }
}
