using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject_Backend.ViewModel
{
    public class ProductCreateViewModel
    {
        [Required]
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile ProductImage { get; set; }
        public int CategoryID { get; set; }
    }
}
