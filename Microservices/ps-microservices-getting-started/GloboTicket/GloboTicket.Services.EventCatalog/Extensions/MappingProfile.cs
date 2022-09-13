using AutoMapper;
using GloboTicket.Services.EventCatalog.Profiles;

namespace GloboTicket.Services.EventCatalog.Extensions
{
    public static class MappingProfile
    {
        public static MapperConfiguration InitilializeAutomapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EventProfile());
                cfg.AddProfile(new CategoryProfile());
            }
            );
            return config;
        }
    }
}
