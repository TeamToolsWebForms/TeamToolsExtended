using System;

namespace TeamTools.Logic.Mvp.Profile.Home
{
    public class CreateNoteEventArgs : EventArgs
    {
        public CreateNoteEventArgs(string title, string content, string userId)
        {
            this.Title = title;
            this.Content = content;
            this.UserId = userId;
        }

        public string UserId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
