using Bytes2you.Validation;
using TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsMain.Contracts;
using TeamTools.Logic.Services.Contracts;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsMain
{
    public class OrganizationDetailsPresenter : Presenter<IOrganizationDetailsView>
    {
        private readonly IUserService userService;
        private readonly IJsonService jsonService;
        private readonly IOrganizationService organizationService;

        public OrganizationDetailsPresenter(
            IOrganizationDetailsView view,
            IUserService userService,
            IJsonService jsonService,
            IOrganizationService organizationService)
            : base(view)
        {
            Guard.WhenArgument(userService, "User Service").IsNull().Throw();
            Guard.WhenArgument(jsonService, "Json Service").IsNull().Throw();
            Guard.WhenArgument(organizationService, "Organization Service").IsNull().Throw();

            this.View.LoadAllUsersWithoutCurrentMembers += this.View_LoadAllUsersWithoutCurrentMembers;
            this.View.LeaveOrganization += this.View_LeaveOrganization;
            this.View.CheckIfUserPersistInOrganization += this.View_CheckIfUserPersistInOrganization;

            this.userService = userService;
            this.jsonService = jsonService;
            this.organizationService = organizationService;
        }

        private void View_CheckIfUserPersistInOrganization(object sender, OrganizationDetailsEventArgs e)
        {
            this.View.Model.CanVisitOrganizationDetails = this.organizationService.CanUserJoinOrganization(e.OrganizationId, e.Username);
        }

        private void View_LeaveOrganization(object sender, OrganizationDetailsEventArgs e)
        {
            this.organizationService.RemoveUserFromOrganization(e.UserId, e.OrganizationId);
        }

        private void View_LoadAllUsersWithoutCurrentMembers(object sender, OrganizationDetailsEventArgs e)
        {
            var users = this.userService.GetAllUsernamesWithoutMembers(e.UserId, e.OrganizationId);
            this.View.Model.UsersWithoutCurrentMembersJson = this.jsonService.GetAsJson(users);
        }
    }
}
