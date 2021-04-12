using Microsoft.AspNetCore.Identity;
using ShareModel;
using System.ComponentModel.DataAnnotations;

namespace MyProject_Backend.Models
{
    public class Rate
    {
        [Key]
        public int idRate { get; set; }

        public string Value { get; set; }

        public int ProductId { get; set; }

        public string  UserId { get; set; }
    }
}
