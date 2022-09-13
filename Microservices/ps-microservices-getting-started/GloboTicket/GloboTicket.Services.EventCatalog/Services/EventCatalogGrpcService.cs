using GloboTicket.Grpc;
using GloboTicket.Services.EventCatalog.Repositories;
using AutoMapper;
using System.Threading.Tasks;
using Grpc.Core;
using System.Collections.Generic;


namespace GloboTicket.Services.EventCatalog.Services
{
    public class EventCatalogGrpcService : Events.EventsBase
    {

        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;


        public EventCatalogGrpcService(IEventRepository eventRepository, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;

           
        }
        //Events
        //Descending order of granularity
        public override async Task<GetAllEventsResponse> GetAll(GetAllEventsRequest request, ServerCallContext context)
        {
            var response = new GetAllEventsResponse();
            var events = await _eventRepository.GetEvents(System.Guid.Empty);
            response.Events.Add(_mapper.Map<List<Event>>(events));
           
            return response;
        }

        public override async Task<GetAllEventsResponse> GetAllByCategoryId(GetAllEventsByCategoryIdRequest request, ServerCallContext context)
        {
            var response = new GetAllEventsResponse();
            var events = await _eventRepository.GetEvents(System.Guid.Parse(request.CategoryId));
           response.Events.Add(_mapper.Map<List<Event>>(events));
            return response;

        }



        public override async Task<GetByEventIdResponse> GetByEventId(GetByEventIdRequest request, ServerCallContext context)
        {
            var response = new GetByEventIdResponse();
            var eventById = await _eventRepository.GetEventById(System.Guid.Parse(request.EventId));
            response.Event= _mapper.Map<Event>(eventById);
            return response;
        }

        //Categories
        public override async Task<GetAllCategoriesResponse> GetAllCategories(GetAllCategoriesRequest request, ServerCallContext context)
        {
            var response = new GetAllCategoriesResponse();
            var categories = await _categoryRepository.GetAllCategories();
            response.Categories.Add(_mapper.Map<List<Category>>(categories));
            return response;
        }

    }


}
