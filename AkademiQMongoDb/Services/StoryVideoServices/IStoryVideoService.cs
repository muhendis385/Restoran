using AkademiQMongoDb.Dtos.StoryVideoDto;

namespace AkademiQMongoDb.Services.StoryVideoServices
{
    public interface IStoryVideoService
    {
        Task<ResultVideoDto> GetStoryVideoAsync();
        Task CreateStoryVideoAsync(CreateVideoDto createStoryVideoDto);
        Task UpdateStoryVideoAsync(UpdateVideoDto updateStoryVideoDto);
        Task DeleteStoryVideoAsync(string id);
        Task<GetVideoByIdDto> GetStoryVideoByIdAsync(string id);
    }
}
