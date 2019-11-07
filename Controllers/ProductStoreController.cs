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


        //total revenue for a specific day
        [HttpGet("/productstore/revenue")]
        public double GetRevenue(DateTime date)
        {
            double revenue = 0;
            foreach (var p in _store.GetProducts())
            {
                if (p.date.Date == date.Date)
                {
                    revenue = revenue + p.price;
                }
            }            
            return revenue;
        }

        //revenue grouped by article
        [HttpGet("/productstore/statistics")]
        public IActionResult Get(string category)
        {   
            //should return a list with all products and their total revenue
            return new JsonResult("result");
        }

        //returns total #products for a specific day
        [HttpGet("/productstore/numproducts")]
        public int GetNumProducts(DateTime date)
        {
            return _store.GetProducts().Where(p => p.date.Date == date.Date).Count();
        }
    }
}