using System;
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

            this.projectService = projectService;
            this.userService = userService;
        }

        private void View_DeleteUserProject(object sender, MyProjectsEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void View_UpdateUserProject(object sender, MyProjectsEventArgs e)
        {
            this.projectService.Update(e.ProjectId, e.ProjectName);
            var foundUser = this.userService.GetByIdWithFilteredProjects(e.UserId, e.Username);
            this.View.Model.User = foundUser;
        }

        private void View_LoadUserProjects(object sender, MyProjectsEventArgs e)
        {
            var foundUser = this.userService.GetByIdWithFilteredProjects(e.UserId, e.Username);
            this.View.Model.User = foundUser;
        }
    }
}
