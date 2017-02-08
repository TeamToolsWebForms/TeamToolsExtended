using System;

namespace TeamTools.Logic.Mvp.Profile.MyProjects
{
    public class MyProjectsEventArgs : EventArgs
    {
        public MyProjectsEventArgs(string userId, string username)
            : this(userId, username, -1)
        {
        }

        public MyProjectsEventArgs(string userId, string username, int projectId)
            : this(userId, username, projectId, null)
        {
        }

        public MyProjectsEventArgs(string userId, string username, int projectId, string projectName)
        {
            this.UserId = userId;
            this.Username = username;
            this.ProjectId = projectId;
            this.ProjectName = projectName;
        }

        public string UserId { get; set; }

        public string Username { get; set; }

        public int ProjectId { get; set; }

        public string ProjectName { get; set; }
    }
}
