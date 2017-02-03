namespace TeamTools.Logic.Data.Models
{
    public class UserLogo
    {
        public int Id { get; set; }

        public byte[] Image { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
