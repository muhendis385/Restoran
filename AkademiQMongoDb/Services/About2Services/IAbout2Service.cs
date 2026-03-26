using AkademiQMongoDb.Dtos.AboutSection1;
using AkademiQMongoDb.Dtos.AboutSection2;

namespace AkademiQMongoDb.Services.About2Services
{
    public interface IAbout2Service
    {
        Task<List<ResultAbout2Dto>> GetAllAbout2Async();
        Task CreateAbout2Async(CreateAbout2Dto createAbout2Dto);
        Task UpdateAbout2Async(UpdateAbout2Dto updateAbout2Dto);
        Task DeleteAbout2Async(string id);
        Task<GetAbout2ByIdDto> GetAbout2ByIdAsync(string id);

    }
}
