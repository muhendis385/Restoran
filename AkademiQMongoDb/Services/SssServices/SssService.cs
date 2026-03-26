using AkademiQMongoDb.Dtos.ProductDto;
using AkademiQMongoDb.Dtos.SSSDto;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using AutoMapper;
using MongoDB.Driver;

namespace AkademiQMongoDb.Services.SssServices
{
    public class SssService : ISssService
    {
        private readonly IMongoCollection<SSS> _sssCollection;
        private readonly IMapper _mapper;

        public SssService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _sssCollection = database.GetCollection<SSS>(_databaseSettings.SSSCollectionName);
            _mapper = mapper;
        }

        public async Task CreateSSSAsync(CreateSSSDto createsssDto)
        {
            var value = _mapper.Map<SSS>(createsssDto);
            await _sssCollection.InsertOneAsync(value);
        }

        public async Task DeleteSSSAsync(string id)
        {
            await _sssCollection.DeleteOneAsync(x => x.SSSId == id);
        }

        public async Task<List<ResultSSSDto>> GetAllSSSAsync()
        {
            var values = await _sssCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSSSDto>>(values);
        }

        public async Task<GetSSSByIdDto> GetSSSByIdAsync(string id)
        {
            var value = await _sssCollection.Find(x => x.SSSId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetSSSByIdDto>(value);

        }

        public async Task UpdateSSSAsync(UpdateSSSDto updatesssDto)
        {
            var value = _mapper.Map<SSS>(updatesssDto);
            await _sssCollection.FindOneAndReplaceAsync(x => x.SSSId == updatesssDto.SSSId, value);
        }
    }
}
