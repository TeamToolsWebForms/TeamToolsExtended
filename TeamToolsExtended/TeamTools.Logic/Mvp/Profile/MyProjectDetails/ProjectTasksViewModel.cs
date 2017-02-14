using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Mvp.Profile.MyProjectDetails
{
    public class ProjectDetailsViewModel
    {
        public ProjectDTO Project { get; set; }

        public ProjectTaskDTO EditableTask { get; set; }

        public ProjectDocumentDTO DocumentInfo { get; set; }

        public decimal[] AllCosts { get; set; }

        public string AllDays { get; set; }

        public int TotalDays { get; set; }

        public decimal TotalCost { get; set; }
    }
}
