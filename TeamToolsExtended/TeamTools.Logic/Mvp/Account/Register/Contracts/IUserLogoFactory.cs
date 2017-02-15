using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Mvp.Account.Register.Contracts
{
    public interface IUserLogoFactory
    {
        UserLogo CreateUserLogo(byte[] image);
    }
}
