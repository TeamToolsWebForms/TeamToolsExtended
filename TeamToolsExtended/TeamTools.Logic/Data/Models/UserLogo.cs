namespace TeamTools.Logic.Data.Models
{
    public class UserLogo
    {
        public UserLogo()
        {
        }

        public UserLogo(byte[] image)
        {
            this.Image = image;
        }

        public int Id { get; set; }

        public byte[] Image { get; set; }
    }
}
