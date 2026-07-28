using Application.DTOs.ApiResponseDTO;
using Application.DTOs.RequestDTOs;
using Application.DTOs.ResponseDTOs;
using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace template_demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct(int pageIndex, int pageSize)
        {
            var (list, totalCount) = await _productService.GetAllProductsAsync(pageIndex, pageSize);
            var pagedData = new PagedResult<ProductResponseDTO>(list, totalCount, pageIndex, pageSize);
            return Ok(ApiResponse.Success("Danh sach san pham", pagedData));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductRequestDTO productCreateDTO)
        {
            var product = await _productService.CreateProductAsync(productCreateDTO);
            return Ok(ApiResponse.Success("Tao san pham thanh cong", product));
        }
    }
}
