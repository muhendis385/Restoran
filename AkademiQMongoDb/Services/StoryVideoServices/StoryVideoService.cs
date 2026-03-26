using AkademiQMongoDb.Dtos.StoryVideoDto;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using AutoMapper;
using MongoDB.Driver;

namespace AkademiQMongoDb.Services.StoryVideoServices
{
    public class StoryVideoService : IStoryVideoService
    {
        private readonly IMongoCollection<StoryVideo> _storyVideoCollection;
        private readonly IMapper _mapper;

        public StoryVideoService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _storyVideoCollection = database.GetCollection<StoryVideo>(_databaseSettings.StoryVideoCollectionName);
            _mapper = mapper;
        }

        public async Task<ResultVideoDto> GetStoryVideoAsync()
        {
            var value = await _storyVideoCollection.Find(x => true).FirstOrDefaultAsync();
            return _mapper.Map<ResultVideoDto>(value);
        }

        public async Task CreateStoryVideoAsync(CreateVideoDto createStoryVideoDto)
        {
            var value = _mapper.Map<StoryVideo>(createStoryVideoDto);
            await _storyVideoCollection.InsertOneAsync(value);
        }

        public async Task DeleteStoryVideoAsync(string id)
        {
            await _storyVideoCollection.DeleteOneAsync(x => x.StoryVideoId == id);
        }

        public async Task<GetVideoByIdDto> GetStoryVideoByIdAsync(string id)
        {
            var value = await _storyVideoCollection.Find(x => x.StoryVideoId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetVideoByIdDto>(value);

        }

        public async Task UpdateStoryVideoAsync(UpdateVideoDto updateStoryVideoDto)
        {
            var value = _mapper.Map<StoryVideo>(updateStoryVideoDto);
            await _storyVideoCollection.FindOneAndReplaceAsync(x => x.StoryVideoId == updateStoryVideoDto.StoryVideoId, value);
        }
    }
}
