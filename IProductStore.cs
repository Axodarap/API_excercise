using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_excercise
{
    interface IProductStore
    {
        void Add(string product);

        List<string> GetList();

    }
}
