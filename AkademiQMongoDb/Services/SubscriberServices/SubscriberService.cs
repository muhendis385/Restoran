using AkademiQMongoDb.Dtos.SubscribeDto;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using AutoMapper;
using MongoDB.Driver;

namespace AkademiQMongoDb.Services.SubscriberServices
{
    public class SubscriberService : ISubscriberServices
    {
        private readonly IMongoCollection<Subscriber> _subscriberCollection;
        private readonly IMapper _mapper;

        public SubscriberService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _subscriberCollection = database.GetCollection<Subscriber>(_databaseSettings.SubscriberCollectionName);
            _mapper = mapper;
        }

        public async Task CreateSubscriberAsync(CreateSubscriberDto createSubscriberDto)
        {
            var value = _mapper.Map<Subscriber>(createSubscriberDto);
            await _subscriberCollection.InsertOneAsync(value);
        }

        public async Task<List<ResultSubscriberDto>> GetAllSubscriberAsync()
        {
            var values = await _subscriberCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSubscriberDto>>(values);
        }
        public async Task DeleteSubscriberAsync(string id)
        {
            await _subscriberCollection.DeleteOneAsync(x => x.SubscriberId == id);
        }

    }
}
