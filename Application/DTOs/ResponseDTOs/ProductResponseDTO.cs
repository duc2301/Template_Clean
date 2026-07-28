using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.ResponseDTOs
{
    public class ProductResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int stock { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
