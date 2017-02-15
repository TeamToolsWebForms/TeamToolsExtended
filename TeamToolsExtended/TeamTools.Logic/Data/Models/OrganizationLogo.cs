namespace TeamTools.Logic.Data.Models
{
    public class OrganizationLogo
    {
        public OrganizationLogo()
        {
        }

        public OrganizationLogo(byte[] image)
        {
            this.Image = image;
        }

        public int Id { get; set; }

        public byte[] Image { get; set; }
    }
}
