using AutoMapper;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Services
{
    public class MapperService : IMapperService
    {
        public T MapObject<T>(object source)
        {
            return Mapper.Map<T>(source);
        }
    }
}
