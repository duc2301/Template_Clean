using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.RequestDTOs
{
    public class ProductRequestDTO
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int stock { get; set; }
        public int CategorieId { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;     
    }
}
