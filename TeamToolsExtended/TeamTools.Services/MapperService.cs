using AutoMapper;
using TeamTools.Services.Contracts;

namespace TeamTools.Services
{
    public class MapperService : IMapperService
    {
        public T MapObject<T>(object source)
        {
            return Mapper.Map<T>(source);
        }
    }
}
