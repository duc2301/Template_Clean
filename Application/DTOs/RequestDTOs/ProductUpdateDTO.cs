using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.RequestDTOs
{
    public class ProductUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int stock { get; set; }
        public int CategorieId { get; set; }
        public bool isActive { get; set; } = false;
    }
}
