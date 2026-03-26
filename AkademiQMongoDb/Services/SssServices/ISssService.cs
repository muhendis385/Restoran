using AkademiQMongoDb.Dtos.SSSDto;

namespace AkademiQMongoDb.Services.SssServices
{
    public interface ISssService
    {
        Task<List<ResultSSSDto>> GetAllSSSAsync();
        Task CreateSSSAsync(CreateSSSDto createDto);
        Task UpdateSSSAsync(UpdateSSSDto updateDto);
        Task DeleteSSSAsync(string id);
        Task<GetSSSByIdDto> GetSSSByIdAsync(string id);
    }
}
