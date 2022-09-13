using AutoMapper;
using GloboTicket.Grpc;
using System.Collections.Generic;
namespace GloboTicket.Services.EventCatalog.Extensions
{
      public class AutoMapperEvent : IAutoMapperEvent
      {
          private MapperConfiguration _config;
          public IMapper MapperEvent { get; set; }
          public AutoMapperEvent()
          {
              _config = new MapperConfiguration(cfg =>
              {
                  cfg.CreateMap<GloboTicket.Grpc.Event, GloboTicket.Services.EventCatalog.Entities.Event>();
                  cfg.CreateMap<GloboTicket.Grpc.Category, GloboTicket.Services.EventCatalog.Entities.Category>();
              });
              _config.AssertConfigurationIsValid();

              MapperEvent = _config.CreateMapper();

          }

      }
    





}
