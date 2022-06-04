using CityInfo.API.Entity;

namespace CityInfo.API.Services
{
    public interface ICityInfoRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();

        Task<(IEnumerable<City>,PaginationMetadata)> GetCitiesAsync(string? name,string? searchQuery,int pageSize, int pageNumber);
        Task<City?> GetCityAsync(int cityId,bool includePointsOfInterest);
        Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForCityAsync(int cityId);
        Task<PointOfInterest?> GetPointOfInterestForCityAsync(int cityId, int pointOfInterestId);

        Task<bool> HasCityAsync(int cityId);

        Task<bool> SaveChangesAsync();
        void DeletePointOfInterest(PointOfInterest pointOfInterest);
        Task<bool> ValidateCityName(int cityId, string? cityName);
        Task AddPointOfInterestAsync(int cityId, PointOfInterest pointOfInterestId);
    }
}
