using Bytes2you.Validation;
using System.IO;
using TeamTools.Logic.Mvp.Profile.Home.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Services.Helpers.Contracts;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.Home
{
    public class ProfileHomePresenter : Presenter<IProfileHomeView>
    {
        private readonly IUserService userService;
        private readonly IImageHelper imageHelper;

        public ProfileHomePresenter(
            IProfileHomeView view,
            IUserService userService,
            IImageHelper imageHelper)
            : base(view)
        {
            Guard.WhenArgument(userService, "User Service").IsNull().Throw();
            Guard.WhenArgument(imageHelper, "Image Helper").IsNull().Throw();

            this.View.LoadUserData += this.View_LoadUserData;
            this.View.SaveProfileImage += this.View_SaveProfileImage;

            this.userService = userService;
            this.imageHelper = imageHelper;
        }

        private void View_SaveProfileImage(object sender, ProfileHomeEventArgs e)
        {
            var user = this.userService.GetById(e.Id);
            Stream fileStream = e.UploadedImage.InputStream;
            BinaryReader binaryReader = new BinaryReader(fileStream);
            byte[] imageContent = binaryReader.ReadBytes((int)fileStream.Length);
            user.UserLogo.Image = imageContent;

            this.View.Model.ImageUrl = this.imageHelper.ByteArrayToImageUrl(user.UserLogo.Image);
            this.userService.Update(user);
        }

        private void View_LoadUserData(object sender, ProfileHomeEventArgs e)
        {
            var foundUser = this.userService.GetById(e.Id);
            this.View.Model.User = foundUser;
            this.View.Model.ImageUrl = this.imageHelper.ByteArrayToImageUrl(foundUser.UserLogo.Image);
        }
    }
}
