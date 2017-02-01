namespace TeamTools.Services.Contracts
{
    public interface IMapperService
    {
        T MapObject<T>(object source);
    }
}
