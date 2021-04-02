using System.ComponentModel.DataAnnotations;

namespace ShareModel
{
    public  class CategoryCreateRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
