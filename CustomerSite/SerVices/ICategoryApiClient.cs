using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSite.SerVices
{
   public  interface ICategoryApiClient
    {
        Task<IList<CategoryShare>> GetCategories();
    }
}
