using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Mvp.Profile.MyProjectDetails
{
    public class ProjectDetailsViewModel
    {
        public ProjectDTO Project { get; set; }

        public ProjectTaskDTO EditableTask { get; set; }
    }
}
