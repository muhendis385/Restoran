using AkademiQMongoDb.Dtos.SubscribeDto;

namespace AkademiQMongoDb.Services.SubscriberServices
{
    public interface ISubscriberServices
    {
        Task<List<ResultSubscriberDto>> GetAllSubscriberAsync();

        Task DeleteSubscriberAsync(string id);

        Task CreateSubscriberAsync(CreateSubscriberDto createSubscriberDto);

    }
}
