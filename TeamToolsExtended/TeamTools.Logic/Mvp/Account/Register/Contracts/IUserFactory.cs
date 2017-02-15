using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Mvp.Account.Register.Contracts
{
    public interface IUserFactory
    {
        User CreateUser(string username, string email, string firstName, string lastName, string gender, UserLogo userLogo);
    }
}
