using AkademiQMongoDb.Dtos.FeatureDto;
using AkademiQMongoDb.Dtos.ProductDto;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace AkademiQMongoDb.Services.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly IMongoCollection<Feature> _featureCollection;
        private readonly IMapper _mapper;

        public FeatureService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _featureCollection = database.GetCollection<Feature>(_databaseSettings.FeatureCollectionName);
            _mapper = mapper;
        }

        public async Task<ResultFeatureDto> GetActiveFeatureAsync()
        {
            var value = await _featureCollection.Find(x => true).FirstOrDefaultAsync();
            return _mapper.Map<ResultFeatureDto>(value);
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createfeatureDto)
        {
            var value = _mapper.Map<Feature>(createfeatureDto);
            await _featureCollection.InsertOneAsync(value);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _featureCollection.DeleteOneAsync(x => x.FeatureId == id);
        }

        public async Task<GetFeatureByIdDto> GetFeatureByIdAsync(string id)
        {
            var value = await _featureCollection.Find(x => x.FeatureId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetFeatureByIdDto>(value);

        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updatefeatureDto)
        {
            var value = _mapper.Map<Feature>(updatefeatureDto);
            await _featureCollection.FindOneAndReplaceAsync(x => x.FeatureId == updatefeatureDto.FeatureId, value);
        }

    }
}
