using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_excercise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
  

        [HttpGet]
        public string Get()
        {
            return "yeah ";
        }

        [HttpPost]
        public void Post(Product newProduct)
        {
           //need a fricken database
        }
    }
}