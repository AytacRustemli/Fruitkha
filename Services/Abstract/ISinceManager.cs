using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services.Abstract
{
    public interface ISinceManager
    {
        List<Since> GetAll();
        void Create(Since since);
        void Edit(Since since);
        void Delete(Since since);
        Since GetById(int id);
    }
}
