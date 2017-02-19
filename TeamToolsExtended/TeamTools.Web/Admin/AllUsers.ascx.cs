using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeamTools.Authentication;
using TeamTools.Logic.DTO;
using TeamTools.Logic.Mvp.Admin.AllUsers;
using TeamTools.Logic.Mvp.Admin.AllUsers.Contracts;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace TeamTools.Web.Admin
{
    [PresenterBinding(typeof(AllUsersPresenter))]
    public partial class AllUsers : MvpUserControl<AllUsersViewModel>, IAllUsersView
    {
        public event EventHandler LoadUsers;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadUsers?.Invoke(sender, null);
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            string pattern = this.SearchUsers.Text.ToLower();
            this.Model.Users = this.Model.Users.Where(x => x.UserName.ToLower().Contains(pattern)).ToList();
            this.UsersGrid.DataBind();
        }

        protected void UsersGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.UsersGrid.PageIndex = e.NewPageIndex;
            this.UsersGrid.DataBind();
        }

        public IQueryable<UserDTO> UsersGrid_GetData()
        {
            return this.Model.Users.AsQueryable();
        }

        protected void BanBtn_Click(object sender, EventArgs e)
        {
            var banBtn = sender as Button;
            var manager = this.Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.AddToRole(banBtn.CommandArgument, "banned");
            
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "banSuccess();", true);
        }

        protected void UnbanBtn_Click(object sender, EventArgs e)
        {
            var unbanBtn = sender as Button;
            var manager = this.Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.RemoveFromRole(unbanBtn.CommandArgument, "banned");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "unbanSuccess();", true);
        }

        protected void AdminBtn_Click(object sender, EventArgs e)
        {
            var makeAdminBtn = sender as Button;
            var manager = this.Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.AddToRole(makeAdminBtn.CommandArgument, "admin");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "makeAdminSuccess();", true);
        }

        protected void RemoveAdminBtn_Click(object sender, EventArgs e)
        {
            var removeAdminBtn = sender as Button;
            var manager = this.Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.RemoveFromRole(removeAdminBtn.CommandArgument, "admin");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "removeAdminSuccess();", true);
        }
    }
}