using TeamTools.Mvp.Profile.Home.Contracts;
using TeamTools.Services.Contracts;
using TeamTools.Services.Helpers.Contracts;
using WebFormsMvp;

namespace TeamTools.Mvp.Profile.Home
{
    public class ProfileHomePresenter : Presenter<IProfileHomeView>, IProfileHomePresenter
    {
        private readonly IUserService userService;
        private readonly IImageHelper imageHelper;

        public ProfileHomePresenter(IProfileHomeView view, IUserService userService, IImageHelper imageHelper)
            : base(view)
        {
            this.View.LoadUserData += View_LoadUserData;

            this.userService = userService;
            this.imageHelper = imageHelper;
        }

        private void View_LoadUserData(object sender, ProfileHomeEventArgs e)
        {
            var foundUser = this.userService.GetById(e.Id);
            this.View.Model.User = foundUser;
            this.View.Model.ImageUrl = this.imageHelper.ByteArrayToImageUrl(foundUser.ProfileImage);
        }
    }
}
