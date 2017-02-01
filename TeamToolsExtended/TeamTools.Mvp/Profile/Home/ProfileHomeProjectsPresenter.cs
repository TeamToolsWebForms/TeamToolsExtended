using TeamTools.Mvp.Profile.Home.Contracts;
using TeamTools.Services.Contracts;
using WebFormsMvp;

namespace TeamTools.Mvp.Profile.Home
{
    public class ProfileHomeProjectsPresenter : Presenter<IProfileHomeProjectsView>, IProfileHomeProjectsPresenter
    {
        private readonly IUserService userService;

        public ProfileHomeProjectsPresenter(IProfileHomeProjectsView view, IUserService userService)
            : base(view)
        {
            this.View.LoadUserWithPersonalProjects += View_LoadUserWithPersonalProjects;
            this.userService = userService;
        }

        private void View_LoadUserWithPersonalProjects(object sender, ProfileHomeEventArgs e)
        {
            var foundUser = this.userService.GetByIdWithFilteredProjects(e.Id, e.Username);
            this.View.Model.User = foundUser;
        }
    }
}
