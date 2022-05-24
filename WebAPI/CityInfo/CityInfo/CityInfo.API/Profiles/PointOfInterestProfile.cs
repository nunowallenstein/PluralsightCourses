using AutoMapper;
namespace CityInfo.API.Profiles
{
    public class PointOfInterestProfile : Profile
    {
        public PointOfInterestProfile()
        {
            CreateMap<Entity.PointOfInterest, Models.PointOfInterestDto>();
            CreateMap<Models.PointOfInterestForCreationDto,Entity.PointOfInterest>();
            CreateMap<Models.PointOfInterestForUpdateDto, Entity.PointOfInterest>();
            CreateMap<Entity.PointOfInterest, Models.PointOfInterestForUpdateDto>();
        }
    }
}
