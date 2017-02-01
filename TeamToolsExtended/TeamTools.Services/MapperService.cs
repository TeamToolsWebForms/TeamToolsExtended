using AutoMapper;
using TeamTools.Services.Contracts;

namespace TeamTools.Services
{
    public class MapperService : IMapperService
    {
        public IMapper Instance { get; set; }
    }
}
