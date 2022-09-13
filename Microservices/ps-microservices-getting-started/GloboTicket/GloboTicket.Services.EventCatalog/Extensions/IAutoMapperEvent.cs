using AutoMapper;

namespace GloboTicket.Services.EventCatalog.Extensions
{
    public interface IAutoMapperEvent
    {
        IMapper MapperEvent { get; set; }
    }
}
