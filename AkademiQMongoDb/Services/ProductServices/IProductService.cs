using AkademiQMongoDb.Dtos.ProductDto;

namespace AkademiQMongoDb.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto createDto);
        Task UpdateProductAsync(UpdateProductDto updateDto);
        Task DeleteProductAsync(string id);
        Task <GetProductByIdDto> GetProductByIdAsync(string id);

    }
}
