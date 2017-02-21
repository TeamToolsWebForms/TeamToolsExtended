using Bytes2you.Validation;
using TeamTools.Logic.Mvp.Profile.Home.Contracts;
using TeamTools.Logic.Services.Contracts;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.Home
{
    public class ProfileHomeProjectsPresenter : Presenter<IProfileHomeProjectsView>
    {
        private readonly IUserService userService;

        public ProfileHomeProjectsPresenter(IProfileHomeProjectsView view, IUserService userService)
            : base(view)
        {
            Guard.WhenArgument(userService, "User Service").IsNull().Throw();

            this.View.LoadUserWithPersonalProjects += this.View_LoadUserWithPersonalProjects;

            this.userService = userService;
        }

        private void View_LoadUserWithPersonalProjects(object sender, ProfileHomeEventArgs e)
        {
            var foundUser = this.userService.GetByIdWithFilteredProjects(e.Id, e.Username);
            this.View.Model.User = foundUser;
        }
    }
}
