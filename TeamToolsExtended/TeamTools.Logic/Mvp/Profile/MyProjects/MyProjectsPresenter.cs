using TeamTools.Logic.DTO;
using TeamTools.Logic.Mvp.Profile.MyProjects;
using TeamTools.Logic.Mvp.Profile.MyProjects.Contracts;
using TeamTools.Logic.Services.Contracts;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.Home
{
    public class MyProjectsPresenter : Presenter<IMyProjectsView>
    {
        private readonly IProjectService projectService;
        private readonly IUserService userService;

        public MyProjectsPresenter(IMyProjectsView view, IProjectService projectService, IUserService userService)
            : base(view)
        {
            this.View.LoadUserProjects += View_LoadUserProjects;
            this.View.UpdateUserProject += View_UpdateUserProject;
            this.View.DeleteUserProject += View_DeleteUserProject;
            this.View.CreateUserProject += View_CreateUserProject;

            this.projectService = projectService;
            this.userService = userService;
        }

        private void View_CreateUserProject(object sender, MyProjectsEventArgs e)
        {
            this.projectService.CreatePersonalProject(e.ProjectName, e.ProjectDescription, e.Username);
        }

        private void View_DeleteUserProject(object sender, MyProjectsEventArgs e)
        {
            this.projectService.Delete(e.ProjectId);
            var foundUser = this.GetUser(e.UserId, e.Username);
            this.View.Model.User = foundUser;
        }

        private void View_UpdateUserProject(object sender, MyProjectsEventArgs e)
        {
            this.projectService.Update(e.ProjectId, e.ProjectName);
            var foundUser = this.GetUser(e.UserId, e.Username);
            this.View.Model.User = foundUser;
        }

        private void View_LoadUserProjects(object sender, MyProjectsEventArgs e)
        {
            var foundUser = this.GetUser(e.UserId, e.Username);
            this.View.Model.User = foundUser;
        }

        private UserDTO GetUser(string id, string username)
        {
            return this.userService.GetByIdWithFilteredProjects(id, username);
        }
    }
}
