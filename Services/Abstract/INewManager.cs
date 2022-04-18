using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface INewManager
    {
        List<New> GetAll();
        New GetById(int id);
        void Create(New news);
        void Edit(New news);
        void Delete(New news);
        New GetNewById(int? id);
        List<New> GetAll(int? pageNo, int recordSize);
        int GetAllCount();
        List<New> GetNewAll();
    }
}
