namespace TeamTools.Logic.Data.Models
{
    public class ProjectDocument
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }

        public byte[] FileContent { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}
