using AkademiQMongoDb.Dtos.AboutSection2;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using AutoMapper;
using MongoDB.Driver;

namespace AkademiQMongoDb.Services.About2Services
{
    public class About2Service : IAbout2Service
    {
        private readonly IMongoCollection<AboutSection2> _about2Collection;
        private readonly IMapper _mapper;

        public About2Service(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _about2Collection = database.GetCollection<AboutSection2>(_databaseSettings.AboutSection2CollectionName);
            _mapper = mapper;
        }

        public async Task<List<ResultAbout2Dto>> GetAllAbout2Async()
        {
            var values = await _about2Collection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultAbout2Dto>>(values);
        }

        public async Task CreateAbout2Async(CreateAbout2Dto createAbout2Dto)
        {
            var value = _mapper.Map<AboutSection2>(createAbout2Dto);
            await _about2Collection.InsertOneAsync(value);
        }

        public async Task UpdateAbout2Async(UpdateAbout2Dto updateAbout2Dto)
        {
            var value = _mapper.Map<AboutSection2>(updateAbout2Dto);
            // SSSId veya About2Id gibi benzersiz alan üzerinden güncelleme
            await _about2Collection.FindOneAndReplaceAsync(x => x.AboutSection2Id == updateAbout2Dto.AboutSection2Id, value);
        }

        public async Task DeleteAbout2Async(string id)
        {
            await _about2Collection.DeleteOneAsync(x => x.AboutSection2Id == id);
        }

        public async Task<GetAbout2ByIdDto> GetAbout2ByIdAsync(string id)
        {
            var value = await _about2Collection.Find(x => x.AboutSection2Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetAbout2ByIdDto>(value);
        }
    }
}
