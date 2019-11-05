using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_excercise
{
    public interface IProductStore
    {
        void Add(Product product);

        IReadOnlyList<Product> GetList();

    }
}
