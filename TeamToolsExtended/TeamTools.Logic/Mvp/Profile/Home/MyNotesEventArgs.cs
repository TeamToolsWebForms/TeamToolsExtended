using System;

namespace TeamTools.Logic.Mvp.Profile.Home
{
    public class MyNotesEventArgs : EventArgs
    {
        public MyNotesEventArgs(string id)
        {
            this.Id = id;
        }

        public string Id { get; set; }
    }
}
