using Bytes2you.Validation;
using TeamTools.Logic.Mvp.Profile.Home.Contracts;
using TeamTools.Logic.Services.Contracts;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.Home
{
    public class ProfileHomeOrganizationsPresenter : Presenter<IProfileHomeOrganizationsView>
    {
        private readonly IUserService userService;

        public ProfileHomeOrganizationsPresenter(IProfileHomeOrganizationsView view, IUserService userService)
            : base(view)
        {
            Guard.WhenArgument(userService, "User Service").IsNull().Throw();

            this.View.LoadUserData += View_LoadUserData;

            this.userService = userService;
        }

        private void View_LoadUserData(object sender, ProfileHomeEventArgs e)
        {
            var foundUser = this.userService.GetById(e.Id);
            this.View.Model.User = foundUser;
        }
    }
}
