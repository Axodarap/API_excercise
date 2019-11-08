using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

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

        /// <summary>
        /// Insert a new product into the storage.
        [HttpPost]
        public void Post(Product newProduct)
        {
            _store.Add(newProduct);
        }

        /// <summary>
        /// Returns all products sold
        /// </summary>   
        /// <returns>List of all sold articles</returns> 
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_store.GetProducts().ToArray());
        }


        /// <summary>
        /// Retrieve total revenue for a specific day
        /// </summary>
        /// <param name="date">The date of the desired revenue per day</param>
        /// <returns>Revenue per day</returns>
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

        /// <summary>
        /// Retrieve total revenue for all products in the same category
        /// </summary>
        /// <returns>Revenue statistics grouped by category</returns>
        [HttpGet("/productstore/statistics")]
        public IActionResult GetStatistics()
        {
            Dictionary<string, double> statistics = new Dictionary<string, double>();

            foreach(var p in _store.GetProducts())
            {
                if(statistics.ContainsKey(p.category))
                {
                    statistics[p.category] += p.price;
                }
                else  //if product is not in the dictionary yet
                {
                    statistics.Add(p.category, p.price);
                }
            }
            return new JsonResult(statistics);
        }

        /// <summary>
        /// Retrieve number of sold producst per day
        /// </summary>
        /// <param name="date">The date of the desired number of sold products per day</param>
        /// <returns>Number of sold products per day</returns>
        [HttpGet("/productstore/numproducts")]
        public int GetNumProducts(DateTime date)
        {
            return _store.GetProducts().Where(p => p.date.Date == date.Date).Count();
        }
    }
}