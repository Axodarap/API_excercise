using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_excercise.Controllers
{
    //TODO implement filtering

    [ApiController]
    [Route("[controller]")]
    public class ProductStoreController : ControllerBase
    {
        private readonly IProductStore _store;

        //constructor gets called automatically by framework 
        public ProductStoreController(IProductStore store)  
        {
            _store = store;
        }

        [HttpPost]
        public void Post(Product newProduct)
        {
            _store.Add(newProduct);
        }

        //returns all the date of all the products stored in the list 
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_store.GetProducts().ToArray());
        }

        [HttpGet("/productstore/{category}")]
        public IActionResult Get(string category)
        {
            return new JsonResult(_store.GetProducts().Where(p => p.category == category).ToList());
        }

        [HttpGet("/productstore/money")]
        public double GetMoney()
        {
            return 10.23;
        }


    }
}