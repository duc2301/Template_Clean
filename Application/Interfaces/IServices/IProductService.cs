using Application.DTOs.RequestDTOs;
using Application.DTOs.ResponseDTOs;

namespace Application.Interfaces.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDTO>> GetAllProductsAsync();
        Task<ProductResponseDTO> GetProductByIdAsync(int productId);
        Task<ProductResponseDTO> CreateProductAsync(ProductRequestDTO productDto);
        Task<ProductResponseDTO> UpdateProductAsync(ProductUpdateDTO productDto);
        Task DeleteProductAsync(int productId);
    }
}
