namespace TeamTools.Logic.Services.Helpers.Contracts
{
    public interface IDirectoryHelper
    {
        bool Exists(string path);

        void CreateDirectory(string path);
    }
}
