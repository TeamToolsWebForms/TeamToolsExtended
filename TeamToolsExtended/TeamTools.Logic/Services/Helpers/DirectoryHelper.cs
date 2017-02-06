using System.IO;
using TeamTools.Logic.Services.Helpers.Contracts;

namespace TeamTools.Logic.Services.Helpers
{
    public class DirectoryHelper : IDirectoryHelper
    {
        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        public bool Exists(string path)
        {
            return Directory.Exists(path);
        }
    }
}
