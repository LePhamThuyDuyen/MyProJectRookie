using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareModel
{
    public class ProductFromCategory
    {
        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }
    }
}
