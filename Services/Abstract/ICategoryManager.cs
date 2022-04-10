using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services.Abstract
{
    public interface ICategoryManager
    {
        List<Category> GetAll();
        void Create(Category category);
        void Edit(Category category);
        void Delete(Category category);
        Category GetById(int id);
    }
}
