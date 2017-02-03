using Microsoft.AspNet.Identity.EntityFramework;

namespace TeamTools.Logic.Data.Models
{
    public class UserRole : IdentityRole
    {
        public UserRole()
        {
        }

        public UserRole(string roleName)
            : base(roleName)
        {
        }
    }
}
