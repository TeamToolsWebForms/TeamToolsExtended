namespace TeamTools.Logic.DTO
{
    public class ProjectDocumentDTO
    {
        public ProjectDocumentDTO()
        {
        }

        public ProjectDocumentDTO(string filename, string fileExtension, byte[] fileContent, int projectId)
        {
            this.FileName = filename;
            this.FileExtension = fileExtension;
            this.FileContent = fileContent;
            this.ProjectId = projectId;
        }

        public int Id { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }

        public byte[] FileContent { get; set; }

        public int ProjectId { get; set; }
    }
}
