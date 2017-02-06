using System.Web;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Services.Helpers.Contracts;

namespace TeamTools.Logic.Services
{
    public class FileService : IFileService
    {
        private readonly IDirectoryHelper directoryHelper;

        public FileService(IDirectoryHelper directoryHelper)
        {
            this.directoryHelper = directoryHelper;
        }

        public void SaveFileToServer(string filename, string serverPath, HttpPostedFile postedFile, string username)
        {
            string fullPath = $"{serverPath}{username}";

            if (!this.directoryHelper.Exists(fullPath))
            {
                this.directoryHelper.CreateDirectory(fullPath);
            }

            postedFile.SaveAs($"{fullPath}\\{filename}");
        }
    }
}
