using Business.Contract.Services.UserManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.UserManagement
{
    public class ProfileManager<T> : UserManager<T>, IProfileManager where T : IdentityUser
    {
        public ProfileManager(IUserStore<T> store, IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<T> passwordHasher, IEnumerable<IUserValidator<T>> userValidators,
            IEnumerable<IPasswordValidator<T>> passwordValidators, ILookupNormalizer lookupNormalizer,
            IdentityErrorDescriber identityErrorDescriber, IServiceProvider serviceProvider,
            ILogger<UserManager<T>> logger) :
                base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators,
                lookupNormalizer, identityErrorDescriber, serviceProvider, logger)
        {

        }

        public async Task<string> GetNameByUserId(Guid id)
        {
            var user = await FindByIdAsync(id.ToString());
            if (user != null)
            {
                return user.Email;
            }

            return "";
        }
    }
}
