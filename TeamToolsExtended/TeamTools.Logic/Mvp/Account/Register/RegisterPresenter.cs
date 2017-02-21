using Bytes2you.Validation;
using TeamTools.Logic.Mvp.Account.Register.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Services.Helpers.Contracts;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Account.Register
{
    public class RegisterPresenter : Presenter<IRegisterView>
    {
        private readonly IUserService userService;
        private readonly IUserFactory userFactory;
        private readonly IUserLogoFactory userLogoFactory;
        private readonly IFileService fileService;
        private readonly IImageHelper imageHelper;

        public RegisterPresenter(
            IRegisterView view,
            IUserService userService,
            IUserFactory userFactory,
            IUserLogoFactory userLogoFactory,
            IFileService fileService,
            IImageHelper imageHelper)
            : base(view)
        {
            Guard.WhenArgument(userService, "User Service").IsNull().Throw();
            Guard.WhenArgument(userFactory, "User Factory").IsNull().Throw();
            Guard.WhenArgument(userLogoFactory, "UserLogo Factory").IsNull().Throw();
            Guard.WhenArgument(fileService, "File Service").IsNull().Throw();
            Guard.WhenArgument(imageHelper, "Image Helper").IsNull().Throw();

            this.View.GetUser += View_GetUser;

            this.userService = userService;
            this.userFactory = userFactory;
            this.userLogoFactory = userLogoFactory;
            this.fileService = fileService;
            this.imageHelper = imageHelper;
        }

        private void View_GetUser(object sender, RegisterEventArgs e)
        {
            var image = this.imageHelper.GetImage(e.UserLogoPath);
            var convertedImage = this.imageHelper.ImageToByteArray(image);
            var defaultUserLogo = this.userLogoFactory.CreateUserLogo(convertedImage);
            var user = this.userFactory.CreateUser(e.Username, e.Email, e.FistName, e.LastName, e.Gender, defaultUserLogo);
            this.View.Model.User = user;
        }
    }
}
