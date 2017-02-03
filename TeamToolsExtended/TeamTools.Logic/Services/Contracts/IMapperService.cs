namespace TeamTools.Logic.Services.Contracts
{
    public interface IMapperService
    {
        T MapObject<T>(object source);
    }
}
