using System;
using System.Web;

namespace TeamTools.Logic.Mvp.Profile.Home
{
    public class ProfileHomeEventArgs : EventArgs
    {
        public ProfileHomeEventArgs(string id, string username)
        {
            this.Id = id;
            this.Username = username;
        }

        public ProfileHomeEventArgs(string filename, HttpPostedFile postedFile, string userId)
        {
            this.FileName = filename;
            this.UploadedImage = postedFile;
            this.Id = userId;
        }

        public string Id { get; set; }

        public string Username { get; set; }

        public string FileName { get; set; }

        public HttpPostedFile UploadedImage { get; set; }
    }
}
