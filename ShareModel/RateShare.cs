using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareModel
{
   public class RateShare
    {

        public int ProductId { get; set; }

        public string value { get; set; }

        public int UserId { get; set; }
    }
}
