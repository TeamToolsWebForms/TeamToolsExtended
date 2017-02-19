using System;

namespace TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsMain
{
    public class ProjectDetailsMainEventArgs : EventArgs
    {
        public ProjectDetailsMainEventArgs(int projectId)
        {
            this.ProjectId = projectId;
        }

        public int ProjectId { get; private set; }
    }
}
