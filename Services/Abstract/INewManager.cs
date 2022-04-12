using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services.Abstract
{
    public interface INewManager
    {
        List<New> GetAll();
        void Create(New news);
        void Edit(New news);
        void Delete(New news);
        New GetById(int id);
    }
}
