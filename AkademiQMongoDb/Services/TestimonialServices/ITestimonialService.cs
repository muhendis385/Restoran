using AkademiQMongoDb.Dtos.ProductDto;
using AkademiQMongoDb.Dtos.TestimonialDto;

namespace AkademiQMongoDb.Services.TestimonialServices
{
    public interface ITestimonialService
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();
        Task CreateTestimonialAsync(CreateTestimonialDto createtestimonialDto);
        Task UpdateTestimonialAsync(UpdateTestimonialDto updatetestimonialDto);
        Task DeleteTestimonialAsync(string id);
        Task<GetTestimonialByIdDto> GetTestimonialByIdAsync(string id);
    }
}
