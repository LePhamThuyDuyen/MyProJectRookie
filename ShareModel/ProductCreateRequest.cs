using Microsoft.AspNetCore.Http;

namespace ShareModel
{
    public  class ProductCreateRequest
    {
        //public int ProductID { get; set; }

        public int CategoryID { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ImageRequest { get; set; }
    }
}
