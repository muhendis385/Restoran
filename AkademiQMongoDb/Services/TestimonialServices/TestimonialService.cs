using AkademiQMongoDb.Dtos.ProductDto;
using AkademiQMongoDb.Dtos.TestimonialDto;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using MongoDB.Driver;

namespace AkademiQMongoDb.Services.TestimonialServices
{
    public class TestimonialService : ITestimonialService
    {
        private readonly IMongoCollection<Testimonial> _testimonialCollection;
        private readonly IMapper _mapper;

        public TestimonialService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _testimonialCollection = database.GetCollection<Testimonial>(_databaseSettings.TestimonialCollectionName);
            _mapper = mapper;
        }


        public async Task CreateTestimonialAsync(CreateTestimonialDto createtestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(createtestimonialDto);
            await _testimonialCollection.InsertOneAsync(value);
        }

        public async Task DeleteTestimonialAsync(string id)
        {
            await _testimonialCollection.DeleteOneAsync(x => x.TestimonialId == id);
        }

        public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
        {
            var value = await _testimonialCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultTestimonialDto>>(value);
        }

        public async Task<GetTestimonialByIdDto> GetTestimonialByIdAsync(string id)
        {
            var value = await _testimonialCollection.Find(x => x.TestimonialId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetTestimonialByIdDto>(value);
        }

        public async Task UpdateTestimonialAsync(UpdateTestimonialDto updatetestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(updatetestimonialDto);
            await _testimonialCollection.FindOneAndReplaceAsync(x =>x.TestimonialId == updatetestimonialDto.TestimonialId, value);
        }

    }
}
