using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services.Abstract
{
    public interface IOrganicManager
    {
        List<Organic> GetAll();
        void Create(Organic organic);
        void Edit(Organic organic);
        void Delete(Organic organic);
        Organic GetById(int id);
    }
}
