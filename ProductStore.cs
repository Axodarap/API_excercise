using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_excercise
{
    public class ProductStore : IProductStore
    {
        private readonly List<Product> _products;

        public ProductStore()
        {
            _products = new List<Product>();
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public IReadOnlyList<Product> GetProducts()
        {
            return _products;
        }

    }
}
