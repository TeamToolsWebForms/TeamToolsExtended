using System.Web;

namespace TeamTools.Logic.Services.Contracts
{
    public interface IFileService
    {
        void SaveFileToServer(string filename, string serverPath, HttpPostedFile postedFile, string username);
    }
}
