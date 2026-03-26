using AkademiQMongoDb.Dtos.AboutSection1;

namespace AkademiQMongoDb.Services.About1Services
{
    public interface IAbout1Service
    {
        Task<ResultAbout1Dto> GetActiveAbout1Async();
        Task CreateAbout1Async(CreateAbout1Dto about1Dto);
        Task UpdateAbout1Async(UpdateAbout1Dto about1Dto);
        Task DeleteAbout1Async(string id);
        Task<GetAbout1ByIdDto> GetAbout1ByIdAsync(string id);
    }
}
