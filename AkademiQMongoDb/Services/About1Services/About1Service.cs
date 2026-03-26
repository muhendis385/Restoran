using AkademiQMongoDb.Dtos.AboutSection1;
using AkademiQMongoDb.Dtos.FeatureDto;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Services.FeatureServices;
using AkademiQMongoDb.Settings;
using AutoMapper;
using MongoDB.Driver;

namespace AkademiQMongoDb.Services.About1Services
{
    public class About1Service : IAbout1Service
    {
            private readonly IMongoCollection<AboutSection1> _about1Collection;
            private readonly IMapper _mapper;

            public About1Service(IMapper mapper, IDatabaseSettings _databaseSettings)
            {
                var client = new MongoClient(_databaseSettings.ConnectionString);
                var database = client.GetDatabase(_databaseSettings.DatabaseName);
                _about1Collection = database.GetCollection<AboutSection1>(_databaseSettings.AboutSection1CollectionName);
                _mapper = mapper;
            }

            public async Task<ResultAbout1Dto> GetActiveAbout1Async()
            {
                var value = await _about1Collection.Find(x => true).FirstOrDefaultAsync();
                return _mapper.Map<ResultAbout1Dto>(value);
            }

            public async Task CreateAbout1Async(CreateAbout1Dto createAbout1Dto)
            {
                var value = _mapper.Map<AboutSection1>(createAbout1Dto);
                await _about1Collection.InsertOneAsync(value);
            }

            public async Task DeleteAbout1Async(string id)
            {
                await _about1Collection.DeleteOneAsync(x => x.AboutSection1Id == id);
            }

            public async Task<GetAbout1ByIdDto> GetAbout1ByIdAsync(string id)
            {
                var value = await _about1Collection.Find(x => x.AboutSection1Id == id).FirstOrDefaultAsync();
                return _mapper.Map<GetAbout1ByIdDto>(value);

            }

            public async Task UpdateAbout1Async(UpdateAbout1Dto updateAbout1Dto)
            {
                var value = _mapper.Map<AboutSection1>(updateAbout1Dto);
                await _about1Collection.FindOneAndReplaceAsync(x => x.AboutSection1Id == updateAbout1Dto.AboutSection1Id, value);
            }
        }
}
