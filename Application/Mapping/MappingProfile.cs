using Application.DTOs.RequestDTOs;
using Application.DTOs.ResponseDTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {  

        public MappingProfile()
        {
            // --- Account (giữ nguyên bản gốc) ---
            CreateMap<Product, ProductResponseDTO>().ReverseMap();
            CreateMap<Product, ProductRequestDTO>().ReverseMap();
            CreateMap<Product, ProductUpdateDTO>().ReverseMap();
        }
    }
}
