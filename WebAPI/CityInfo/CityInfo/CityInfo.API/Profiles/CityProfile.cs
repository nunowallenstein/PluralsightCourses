using AutoMapper;

namespace CityInfo.API.Profiles
{

    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<Entity.City, Models.CityWithoutPointsOfInterestDto>();
            CreateMap<Entity.City, Models.CityDto>();
        }

    }
}
