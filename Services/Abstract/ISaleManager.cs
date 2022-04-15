using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services.Abstract
{
    public interface ISaleManager
    {
        List<Sale> GetAll();
        void Create(Sale sale);
        void Edit(Sale sale);
        void Delete(Sale sale);
        Sale GetById(int id);
    }
}
