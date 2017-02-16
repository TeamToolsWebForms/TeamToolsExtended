using System;

namespace TeamTools.Logic.Mvp.Profile.MyProjectDetails
{
    public class ProjectDocumentsEventArgs : EventArgs
    {
        public ProjectDocumentsEventArgs(int projectId, string pattern)
        {
            this.ProjectId = projectId;
            this.Pattern = pattern;
        }

        public int ProjectId { get; set; }

        public string Pattern { get; set; }
    }
}
