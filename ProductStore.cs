using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_excercise
{
    public class ProductStore : IProductStore
    {
        private List<string> _products;

        public ProductStore()
        {
            _products = new List<string>();
        }

        public void Add(string product)
        {
            _products.Add(product);
        }

        public List<string> GetList()
        {
            return _products;
        }

    }
}
