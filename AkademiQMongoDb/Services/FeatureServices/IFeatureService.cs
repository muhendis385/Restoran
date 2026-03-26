using AkademiQMongoDb.Dtos.FeatureDto;

namespace AkademiQMongoDb.Services.FeatureServices
{
    public interface IFeatureService
    {
        Task<ResultFeatureDto> GetActiveFeatureAsync(); 
        Task CreateFeatureAsync(CreateFeatureDto featuretDto);
        Task UpdateFeatureAsync(UpdateFeatureDto featureDto);
        Task DeleteFeatureAsync(string id);
        Task<GetFeatureByIdDto> GetFeatureByIdAsync(string id);

    }
}
