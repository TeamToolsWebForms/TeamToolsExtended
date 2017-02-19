using System.Collections.Generic;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Mvp.Admin.AllUsers
{
    public class AllUsersViewModel
    {
        public ICollection<UserDTO> Users { get; set; }
    }
}
