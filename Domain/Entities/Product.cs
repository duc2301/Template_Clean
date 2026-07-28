using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int stock { get; set; }
        public int CategorieId { get; set; }
        public bool isActive { get; set; } = false;
        public DateTime CreateAt { get; set; } = DateTime.Now;

        public Categorie Categorie { get; set; } 
    }
}
