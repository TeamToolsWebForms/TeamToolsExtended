using AutoMapper;

namespace TeamTools.Services.Contracts
{
    public interface IMapperService
    {
        IMapper Instance { get; set; }
    }
}
