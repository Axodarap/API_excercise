using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_excercise
{
    public class Product
    {
        [StringLength(32, ErrorMessage = "Article number must be no longer than 32 characters")]
        public string articleNumber { get; set;}
        public double price { get; set; }
        public string category { get; set; }
        public DateTime date { get; set; }
    }
}
