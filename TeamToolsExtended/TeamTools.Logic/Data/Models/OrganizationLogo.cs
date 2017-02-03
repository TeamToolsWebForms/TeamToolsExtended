namespace TeamTools.Logic.Data.Models
{
    public class OrganizationLogo
    {
        public int Id { get; set; }

        public byte[] Image { get; set; }

        public int OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
