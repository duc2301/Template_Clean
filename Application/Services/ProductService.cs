using Application.DTOs.RequestDTOs;
using Application.DTOs.ResponseDTOs;
using Application.Interfaces.IServices;
using Application.Interfaces.IUnitOfWorks;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductResponseDTO> CreateProductAsync(ProductRequestDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            product.CreateAt = DateTime.Now;
            await _unitOfWork.Repository<Product>().CreateAsync(product);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ProductResponseDTO>(product);
        }

        public async Task DeleteProductAsync(int productId)
        {
            _unitOfWork.Repository<Product>().DeleteById(productId);
            await _unitOfWork.SaveChangesAsync();            
        }

        public async Task<(IEnumerable<ProductResponseDTO>, int totalCount)> GetAllProductsAsync(int Pageindex, int PageSize)
        {
            var totalCountList = await _unitOfWork.Repository<Product>()
            .GetAsync(query => query.Where(p => p.isActive == true));

            int totalCount = totalCountList.Count(); 

            var list = await _unitOfWork.Repository<Product>()
                .GetAsync(query => query                
                .Where(p => p.isActive == true)
                .OrderByDescending(p => p.CreateAt)
                .Skip((Pageindex - 1) * PageSize)
                .Take(PageSize)
                );

            return (_mapper.Map<IEnumerable<ProductResponseDTO>>(list), totalCount);
        }

        public async Task<IEnumerable<ProductResponseDTO>> GetAllProductsAsync()
        {
            var list = await _unitOfWork.Repository<Product>().GetAllAsync();
            return _mapper.Map<IEnumerable<ProductResponseDTO>>(list);
        }

        public async Task<ProductResponseDTO> GetProductByIdAsync(int productId)
        {
            var entity  = await _unitOfWork.Repository<Product>().GetByIdAsync(productId);
            return _mapper.Map<ProductResponseDTO>(entity);
        }

        public async Task<ProductResponseDTO> UpdateProductAsync(ProductUpdateDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _unitOfWork.Repository<Product>().Update(product);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ProductResponseDTO>(product);
        }
    }
}
