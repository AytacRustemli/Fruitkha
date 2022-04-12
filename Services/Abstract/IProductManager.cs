using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services.Abstract
{
    public interface IProductManager
    {
        List<Product> GetAll();
        void Create(Product product);
        void Edit(Product product);
        void Delete(Product product);
        Product GetById(int id);
    }
}
