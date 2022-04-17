using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services.Abstract
{
    public interface IFreeManager
    {
        List<Free> GetAll();
        Free GetById(int? id);
        void Create(Free free);
        void Edit(Free free);
        void Delete(Free free);
        List<Free> GetFreeAll();
    }
}
