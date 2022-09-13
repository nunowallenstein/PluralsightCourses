using AutoMapper;
using System;
using Google.Protobuf.WellKnownTypes;

namespace GloboTicket.Services.EventCatalog.Profiles
{
    public class EventProfile: Profile
    {
        public EventProfile()
        {
            CreateMap<Entities.Event, Models.EventDto>()
                .ForMember(dest => dest.CategoryName, opts => opts.MapFrom(src => src.Category.Name));
            CreateMap<Entities.Event, GloboTicket.Grpc.Event>();
            CreateMap<Entities.Category, GloboTicket.Grpc.Category>();
            CreateMap<DateTime, Google.Protobuf.WellKnownTypes.Timestamp>().ConvertUsing(x => Timestamp.FromDateTime(DateTime.SpecifyKind(x,DateTimeKind.Utc)));
        }

    }
}
