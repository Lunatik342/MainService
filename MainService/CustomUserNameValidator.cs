using System;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.ServiceModel;
using System.Web.Security;
using MainService.DtoManagers;

namespace MainService
{
    class CustomUserNameValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            var user = new UsersManager().GetUserByNickname(userName);
            if (user == null)
                throw new FaultException("Unknown user name");
            if (IsPasswordMatch(password,user))
                return;
            throw new FaultException("Wrong password");
        }

        public bool IsPasswordMatch(string password, User user)
        {
            var hash = new HashEncryption().HashSha(password, Convert.FromBase64String(user.salt));
            var stringHash = Convert.ToBase64String(hash);
            return stringHash.Equals(user.password);
        }
    }
}
