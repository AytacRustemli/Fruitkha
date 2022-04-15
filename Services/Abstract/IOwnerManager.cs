using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services.Abstract
{
    public interface IOwnerManager
    {
        List<Owner> GetAll();
        Owner GetById(int? id);
        void Create(Owner owner);
        void Edit(Owner owner);
        void Delete(Owner owner);
    }
}
